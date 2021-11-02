using System;
using System.Collections.Generic;
using System.Text;

namespace REAL.Common
{
	public class MyResponse<T>
	{
		public bool	Status { get; set; }
		public string Message { get; set; }
		public T Data { get; set; }
	}
}
