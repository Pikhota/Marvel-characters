using System.Collections.Generic;

namespace MarvelCharacters.Models
{
	public class Events
	{
		public int Available { get; set; }
		public string CollectionURI { get; set; }
		public List<object> Items { get; set; }
		public int Returned { get; set; }
	}
}
