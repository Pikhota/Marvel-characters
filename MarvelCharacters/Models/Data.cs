﻿using System.Collections.Generic;

namespace MarvelCharacters.Models
{
	public class Data
	{
		public int Offset { get; set; }
		public int Limit { get; set; }
		public int Total { get; set; }
		public int Count { get; set; }
		public List<Result> Results { get; set; }
	}
}
