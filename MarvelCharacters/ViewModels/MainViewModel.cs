using MarvelCharacters.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelCharacters.ViewModels
{
	public class MainViewModel
	{
		public string ConnectionState { get; set; }
		public List<Character> Characters { get; set; }
		public string AttributeText { get; set; }
		private Task<RootObject> RootObject { get; set; }
		private readonly MarvelService _marvelService = new MarvelService();
		private readonly ConnectionService _connectionService = new ConnectionService();

		public MainViewModel()
		{
			if(ConnectionService.IsConnection())
			{
				RootObject = _marvelService.GetDataAsync();
				Characters = GetCharacters(RootObject);
				AttributeText = RootObject.Result.AttributionText;
			}

			ConnectionState = _connectionService.CheckConnection();
		}

		public  List<Character> GetCharacters(Task<RootObject> data)
		{
			List<Character> characters = new List<Character>();

			RootObject rootObject = data.Result;

			if(rootObject != null)
			{
				foreach (var item in rootObject.Data.Results)
				{
					characters.Add(new Character
					{
						Name = item.Name,
						Description = string.IsNullOrWhiteSpace(item.Description) ? "No information is available on this character" : item.Description,
						ImagePath = $"{item.Thumbnail.Path}.{item.Thumbnail.Extension}",
					});
				}
			}

			return characters;
		}
	}
}
