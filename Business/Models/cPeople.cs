﻿using System.Collections.Generic;

namespace Business.Models
{
	public class cPeople
	{
		public string name { get; set; }

		public string height { get; set; }

		public string mass { get; set; }

		public string hair_color { get; set; }

		public string skin_color { get; set; }

		public string eye_color { get; set; }

		public string birth_year { get; set; }

		public string gender { get; set; }

		public object homeworld { get; set; }

		public List<dynamic> films { get; set; }

		public List<dynamic> species { get; set; }

		public List<dynamic> vehicles { get; set; }

		public List<dynamic> starships { get; set; }

		public string created { get; set; }

		public string edited { get; set; }

		public string url { get; set; }

		public List<dynamic> peopleSuggestions { get; set; }
	}
}
