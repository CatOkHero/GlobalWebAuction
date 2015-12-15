using System;
using System.Collections.Generic;

namespace ApiModels.Lots
{
	public class LotDetailsApiModel
	{
		public Guid Id { get; set; }
		public Double Price { get; set; }
		public String Address { get; set; }
		public String Description { get; set; }
		public Int16 Quantity { get; set; }
		public virtual List<LotApiModel> Lots { get; set; }
	}
}
