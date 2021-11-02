﻿using System;
using System.Collections.Generic;
using System.Text;

namespace REAL.Common.models
{
	public class ProductModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int Discount { get; set; }
		public string Description { get; set; }
		public string Provider { get; set; }
		public string Category { get; set; }
		public string Image { get; set; }
	}
}
