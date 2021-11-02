using System;
using System.Collections.Generic;
using System.Text;

namespace REAL.Common.utils
{
	public class AgeCalculator
	{
		public static int ByBirthDate(DateTime birth)
		{
			return DateTime.Today.AddTicks(-birth.Ticks).Year - 1;
		}

		public static int ByNullableBirthDate(DateTime? birth)
		{
			return birth == null ? 0 : ByBirthDate(birth.Value);
		}

		public static int ByStringBirthDate(string birth)
		{
			DateTime birthdate;
			if (!DateTime.TryParse(birth, out birthdate))
				return 0;
			else
				return ByBirthDate(birthdate);
		}
	}
}
