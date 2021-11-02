using REAL.Data.generated;
using System.Linq;

namespace REAL.Data.stored
{
	public static class CustomProcedure
	{
		public class SPResponse {
			public int status { get; set; }
			public string message { get; set; }
		}
		public static SPResponse Execute(this MyContext context, int id)
		{
			return context.Raw($"exec dbo.usp_custom {id}", (reader) =>
			{
				var item = new SPResponse();
				item.status = (int)reader["status"];
				item.message = reader["message"].ToString();
				return item;
			}).FirstOrDefault();
		}
	}
}
