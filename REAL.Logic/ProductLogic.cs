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
	public class ProductLogic : BaseLogic
	{
		public ProductLogic(
			MyContext context, 
			IUserResolverService userResolver, 
			MyConfig config) : base(context, userResolver)
		{
		}

		public async Task<MyResponse<List<ProductModel>>> ListAll()
		{
			return await ResponseAsync(async () =>
			{
				var data = await (from p in context.Product
								  orderby p.Name
								  select new ProductModel
								  {
									  Id = p.Id,
									  Name = p.Name,
									  Price = (double)p.Price,
									  Provider = p.Provider,
									  Category = p.Category,
									  Description = p.Description,
									  Discount = p.Discount ?? 0,
									  Image = p.Image
								  }).ToListAsync();
				return data;
			});
		}

		public async Task<MyResponse<ProductModel>>FindById(int id)
		{
			return await ResponseAsync(async () =>
			{
				var data = await (from p in context.Product
								  where p.Id == id
								  select new ProductModel()
								  {
									  Id = p.Id,
									  Name = p.Name,
									  Price = (double)p.Price,
									  Provider = p.Provider,
									  Category = p.Category,
									  Description = p.Description,
									  Discount = p.Discount ?? 0,
									  Image = p.Image
								  }).FirstOrDefaultAsync();

				if (data == null)
					throw new Exception($"No se encontró el producto con id={id}");

				return data;
			});
		}

		public async Task<MyResponse<int>> Insert(ProductModel model)
		{
			return await ResponseAsync(async () =>
			{
				var usr = await UserAsync();

				var product = new Product();
				product.Created = DateTime.Now;
				product.Name = model.Name;
				product.Price = (decimal)model.Price;
				product.Provider = model.Provider;
				product.Discount = model.Discount;
				product.Category = model.Category;
				product.Description = model.Description;
				product.Image = model.Image;

				await context.Product.AddAsync(product);
				await context.SaveChangesAsync();

				return product.Id;
			});
		}

		public async Task<MyResponse<bool>> Update(ProductModel model)
		{
			return await ResponseAsync(async () =>
			{
				var usr = await UserAsync();

				var product = await (from p in context.Product
									 where p.Id == model.Id
									 select p).FirstOrDefaultAsync();

				if (product == null)
					throw new Exception($"No se encontró producto con id = {model.Id}");
				
				product.Updated = DateTime.Now;
				product.Name = model.Name;
				product.Price = (decimal)model.Price;
				product.Provider = model.Provider;
				product.Discount = model.Discount;
				product.Category = model.Category;
				product.Description = model.Description;
				product.Image = model.Image;

				await context.SaveChangesAsync();

				return true;
			});
		}

		public async Task<MyResponse<bool>> Delete(int id)
		{
			return await ResponseAsync(async () =>
			{
				var product = await (from p in context.Product
									 where p.Id == id
									 select p).FirstOrDefaultAsync();

				if (product == null)
					throw new Exception($"No se encontró producto con id = {id}");

				context.Product.Remove(product);
				await context.SaveChangesAsync();

				return true;
			});
		}

	}
}
