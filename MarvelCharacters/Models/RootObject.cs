using System.Text;

namespace MarvelCharacters.Models
{
	public class RootObject
	{
		public int Code { get; set; }
		public string Status { get; set; }
		public string Copyright { get; set; }
		public string AttributionText { get; set; }
		public string AttributionHTML { get; set; }
		public string Etag { get; set; }
		public Data Data { get; set; }
	}
}
