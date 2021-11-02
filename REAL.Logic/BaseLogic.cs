using REAL.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using REAL.Common;
using REAL.Data.generated;
using REAL.Common.models;
using REAL.Logic.interfaces;

namespace REAL.Logic
{
	public class BaseLogic
	{
		protected MyContext context;
		protected IUserResolverService userResolver;
		public BaseLogic(MyContext context, IUserResolverService userResolver)
		{
			this.context = context;
			this.userResolver = userResolver;
		}

		public async Task<AccountModel> UserAsync()
		{
			return await (from u in context.Account
						  where u.Id == userResolver.GetUserId()
						  select new AccountModel()
						  {
							  Id = u.Id,
							  FullName = u.FullName
						  }).FirstOrDefaultAsync();
		}

		public bool HasRole(string role)
		{
			return userResolver.HasRole(role);
		}

		public async Task<MyResponse<T>> ResponseAsync<T>(Func<Task<T>> myaction)
		{
			MyResponse<T> response = new MyResponse<T>();
			try	{
				response.Data = await myaction();
				response.Status = true;
			}
			catch (Exception ex)
			{
				response.Status = false;
				response.Message = ex.Message;
			}
			return response;
		}
	}
}
