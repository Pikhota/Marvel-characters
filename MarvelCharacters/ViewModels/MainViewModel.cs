using MarvelCharacters.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelCharacters.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{
			RootObject = _marvelService.GetDataAsync();
			Characters = GetCharacters(RootObject);
			_connectionState = _marvelService.CheckConnection();
			_attributeText = RootObject.Result.AttributionText;
		}

		private  string _connectionState;
		public string ConnectionState
		{
			get { return _connectionState; }
			set
			{
				_connectionState = value;
				OnPropertyChanged();
			}
		}
		private Task<RootObject> RootObject { get; set; }

		private readonly MarvelService _marvelService = new MarvelService();
		public List<Character> Characters { get; set; }

		private string _attributeText;
		public string AttributeText
		{
			get { return _attributeText; }
			set
			{
				_attributeText = value;
				OnPropertyChanged();
			}
		}
		public static List<Character> GetCharacters(Task<RootObject> data)
		{
			List<Character> characters = new List<Character>();

			foreach (var item in data.Result.Data.Results)
			{
				characters.Add(new Character {
					Name = item.Name,
					Description = item.Description,
					ImagePath = $"{item.Thumbnail.Path}.{item.Thumbnail.Extension}",
				});
			}

			return characters;
		}
	}
}
