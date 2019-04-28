using MarvelCharacters.Models;
using System.Collections.Generic;

namespace MarvelCharacters.ViewModels
{
	public class MainViewModel
	{
		public string ConnectionState { get; set; }
		public List<Character> Characters { get; set; }
		public string AttributeText { get; set; }
		private MarvelData MarvelData { get; set; }
		private readonly ConnectionService _connectionService = new ConnectionService();
		private const string _publicApiKey = "ca1ce146dbac71cc415a6e5804dadbae";
		private const string _privateApiKey = "f228bc563b74b592cabc2db4b827093d6f8369c3";
		private const string _charactersRequest = "/v1/public/characters?";
		private const string _ts = "23";
		private static object locker = new object();
		public MainViewModel()
		{
			if(ConnectionService.IsConnection())
			{
				MarvelData = MarvelService.GetDataAsync(_charactersRequest, _ts, _publicApiKey, _privateApiKey).Result;
				Characters = GetCharacters(MarvelData);
				AttributeText = MarvelData.AttributionText;
			}

			ConnectionState = _connectionService.CheckConnection();
		}

		public  List<Character> GetCharacters(MarvelData marvelData)
		{
			List<Character> characters = new List<Character>();

			if(marvelData != null)
			{
				foreach (var item in marvelData.Data.Results)
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
