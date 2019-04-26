using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MarvelCharacters.ViewModels
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
