using MarvelCharacters.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelCharacters.ViewModels
{
	public class MainViewModel
	{
		public MainViewModel()
		{
			Characters = GetCharacters(_marvelService.GetDataAsync());
			ConnectionState = _marvelService.CheckConnection();
		}

		public string ConnectionState { get; set; }

		private readonly MarvelService _marvelService = new MarvelService();
		public List<Character> Characters { get; set; }

		public static List<Character> GetCharacters(Task<List<Result>> data)
		{
			List<Character> characters = new List<Character>();

			foreach (var item in data.Result)
			{
				characters.Add(new Character {
					Name = item.Name,
					Description = item.Description,
					ImagePath = $"{item.Thumbnail.Path}.{item.Thumbnail.Extension}",
					UrlDetails = item.Urls[0].UrlLink
				});
			}

			return characters;
		}
	}
}
