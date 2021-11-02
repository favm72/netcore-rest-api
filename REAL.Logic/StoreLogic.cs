using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using REAL.Common;
using REAL.Data.generated;
using REAL.Common.models;
using REAL.Logic.interfaces;

namespace REAL.Logic
{
	public class StoreLogic : BaseLogic
	{
		public StoreLogic(
			MyContext context, 
			IUserResolverService userResolver, 
			MyConfig config) : base(context, userResolver)
		{
		}

		public async Task<MyResponse<List<StoreModel>>> ListAll()
		{
			return await ResponseAsync(async () =>
			{
				var data = await (from p in context.Store
								  orderby p.Name
								  select new StoreModel
								  {
									  Id = p.Id,
									  Name = p.Name,
									  Address = p.Address,
									  Image = p.Image
								  }).ToListAsync();
				return data;
			});
		}

		public async Task<MyResponse<StoreModel>>FindById(int id)
		{
			return await ResponseAsync(async () =>
			{
				var data = await (from p in context.Store
								  where p.Id == id
								  select new StoreModel()
								  {
									  Id = p.Id,
									  Name = p.Name,
									  Address = p.Address,
									  Image = p.Image
								  }).FirstOrDefaultAsync();

				if (data == null)
					throw new Exception($"No se encontró la tienda con id={id}");

				return data;
			});
		}

		public async Task<MyResponse<int>> Insert(StoreModel model)
		{
			return await ResponseAsync(async () =>
			{
				var usr = await UserAsync();

				var store = new Store();
				store.Created = DateTime.Now;
				store.Name = model.Name;
				store.Address = model.Address;
				store.Image = model.Image;

				await context.Store.AddAsync(store);
				await context.SaveChangesAsync();

				return store.Id;
			});
		}

		public async Task<MyResponse<bool>> Update(StoreModel model)
		{
			return await ResponseAsync(async () =>
			{
				var usr = await UserAsync();

				var store = await (from p in context.Store
									 where p.Id == model.Id
									 select p).FirstOrDefaultAsync();

				if (store == null)
					throw new Exception($"No se encontró la tienda con id = {model.Id}");
				
				store.Updated = DateTime.Now;
				store.Name = model.Name;
				store.Address = model.Address;
				store.Image = model.Image;

				await context.SaveChangesAsync();

				return true;
			});
		}

		public async Task<MyResponse<bool>> Delete(int id)
		{
			return await ResponseAsync(async () =>
			{
				var store = await (from p in context.Store
									 where p.Id == id
									 select p).FirstOrDefaultAsync();

				if (store == null)
					throw new Exception($"No se encontró la tienda con id = {id}");

				context.Store.Remove(store);
				await context.SaveChangesAsync();

				return true;
			});
		}

	}
}
