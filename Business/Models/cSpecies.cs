using System.Collections.Generic;

namespace Business.Models
{
	public class cSpecies
	{
		public string name { get; set; }

		public string classification { get; set; }

		public string designation { get; set; }

		public string average_height { get; set; }

		public string skin_colors { get; set; }

		public string hair_colors { get; set; }

		public string eye_colors { get; set; }

		public string average_lifespan { get; set; }

		public object homeworld { get; set; }

		public string language { get; set; }

		public List<dynamic> people { get; set; }

		public List<dynamic> films { get; set; }

		public string created { get; set; }

		public List<dynamic> edited { get; set; }

		public string url { get; set; }
	}
}
