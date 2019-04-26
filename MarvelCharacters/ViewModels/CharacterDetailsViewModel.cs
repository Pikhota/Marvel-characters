using MarvelCharacters.Models;

namespace MarvelCharacters.ViewModels
{
	public class CharacterDetailsViewModel
	{
		public string CharacterName { get; set; }
		public string CharacterDescription { get; set; }
		public string CharacterImage { get; set; }
		public CharacterDetailsViewModel(Character character)
		{
			CharacterName = character.Name;
			CharacterDescription = character.Description;
			CharacterImage = character.ImagePath;
		}
	}
}
