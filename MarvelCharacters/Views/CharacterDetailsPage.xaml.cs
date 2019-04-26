using MarvelCharacters.Models;
using MarvelCharacters.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelCharacters.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterDetailsPage : ContentPage
	{
		public CharacterDetailsPage(Character character)
		{
			InitializeComponent();
			BindingContext = new CharacterDetailsViewModel(character);
		}
	}
}