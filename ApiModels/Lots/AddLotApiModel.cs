using System;

namespace ApiModels.Lots
{
	public class AddLotApiModel
	{
		public String Price { get; set; }
		public String Address { get; set; }
		public String Name { get; set; }
		public String Description { get; set; }
		public String Category { get; set; }
		public String SubCategory { get; set; }
		public String Status { get; set; }
	}
}
