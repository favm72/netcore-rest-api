using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using REAL.Common;
using REAL.Data.generated;
using REAL.Common.models;
using REAL.Logic.interfaces;
using System.IO;

namespace REAL.Logic
{
	public class AccountLogic : BaseLogic
	{
		private MyConfig config;
		public AccountLogic(
			MyContext context,
			IUserResolverService userResolver,
			MyConfig config) : base(context, userResolver)
		{
			this.config = config;
		}		

		public async Task<MyResponse<AccountModel>> Login(LoginModel model, Func<AccountModel, List<string>, AccountModel> loginResponse)
		{
			return await ResponseAsync(async () =>
			{
				var found = await (from u in context.Account
								   where u.Username == model.Username
								   select u).FirstOrDefaultAsync();

				var acc = new AccountModel();
				var roles = new List<string>();

				if (found == null)
					throw new Exception("No existe el usuario.");

				if (found.Password != model.Password)
					throw new Exception("Usuario o Clave incorrectas.");
					
				acc.Id = found.Id;
				acc.FullName = found.FullName;
				
				return loginResponse(acc, roles);
			});
		}
	}
}
