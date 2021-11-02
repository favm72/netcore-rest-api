using REAL.Common;
using REAL.Common.models;
using REAL.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace REAL.API.Controllers
{
	[Authorize]
    [ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		private ProductLogic productLogic;
		public ProductController(ProductLogic productLogic)
		{
			this.productLogic = productLogic;
		}

		[HttpGet]
		public async Task<MyResponse<List<ProductModel>>> ListAll()
		{
			return await productLogic.ListAll();
		}
		

		[HttpPost]
		public async Task<MyResponse<int>> Insert(ProductModel model)
		{
			return await productLogic.Insert(model);
        }

		[HttpGet]
		[Route("{id}")]
		public async Task<MyResponse<ProductModel>> FindById(int id)
		{
			return await productLogic.FindById(id);
		}

		[HttpPatch]
		public async Task<MyResponse<bool>> Update(ProductModel model)
		{
			return await productLogic.Update(model);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<MyResponse<bool>> Delete(int id)
		{
			return await productLogic.Delete(id);
		}
	}
}
