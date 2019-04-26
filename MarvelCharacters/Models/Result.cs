using System;
using System.Collections.Generic;

namespace MarvelCharacters.Models
{
	public class Result
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Modified { get; set; }
		public Thumbnail Thumbnail { get; set; }
		public string ResourceURI { get; set; }
		public Comics Comics { get; set; }
		public Series Series { get; set; }
		public Stories Stories { get; set; }
		public Events Events { get; set; }
		public List<Url> Urls { get; set; }
	}
}
