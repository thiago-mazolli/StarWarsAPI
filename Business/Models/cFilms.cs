using System.Collections.Generic;

namespace Business.Models
{
	public class cFilms
	{
		public string title { get; set; }

		public int episode_id { get; set; }

		public string opening_crawl { get; set; }

		public string director { get; set; }

		public string producer { get; set; }

		public string release_date { get; set; }

		public List<dynamic> characters { get; set; }

		public List<dynamic> planets { get; set; }

		public List<dynamic> starships { get; set; }

		public List<dynamic> vehicles { get; set; }

		public List<dynamic> species { get; set; }

		public string created { get; set; }

		public string edited { get; set; }

		public string url { get; set; }
	}
}
