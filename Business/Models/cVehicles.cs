﻿using System.Collections.Generic;

namespace Business.Models
{
	public class cVehicles
	{
		public string name { get; set; }

		public string model { get; set; }

		public string manufacturer { get; set; }

		public string cost_in_credits { get; set; }

		public string length { get; set; }

		public string max_atmosphering_speed { get; set; }

		public string crew { get; set; }

		public string passengers { get; set; }

		public string cargo_capacity { get; set; }

		public string consumables { get; set; }

		public string vehicle_class { get; set; }

		public List<dynamic> pilots { get; set; }

		public List<dynamic> films { get; set; }

		public string created { get; set; }

		public string edited { get; set; }

		public string url { get; set; }
	}
}
