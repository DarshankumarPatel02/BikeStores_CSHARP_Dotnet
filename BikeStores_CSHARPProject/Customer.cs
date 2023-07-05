using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores_CSHARPProject
{
	public class Customer
	{

		//constructor
		public Customer() { }

		//getter and setter
		public int customer_id { get; set; }

		public string first_name { get; set; }

		public string last_name { get; set; }
		public string email { get; set; }

		public string street { get; set; }

		public string city { get; set; }

		public string state { get; set; }

		public string zip_code { get; set; }
	}

}
