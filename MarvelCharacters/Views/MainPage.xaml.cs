using MarvelCharacters.Models;
using Xamarin.Forms;

namespace MarvelCharacters.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void CharactersList_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var character = e.Item as Character;
			await Navigation.PushAsync(new NavigationPage(new CharacterDetailsPage(character)));
		}
	}
}
