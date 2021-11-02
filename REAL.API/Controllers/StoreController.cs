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
	public class StoreController : ControllerBase
	{
		private StoreLogic storeLogic;
		public StoreController(StoreLogic storeLogic)
		{
			this.storeLogic = storeLogic;
		}

		[HttpGet]
		public async Task<MyResponse<List<StoreModel>>> ListAll()
		{
			return await storeLogic.ListAll();
		}
		

		[HttpPost]
		public async Task<MyResponse<int>> Insert(StoreModel model)
		{
			return await storeLogic.Insert(model);
        }

		[HttpGet]
		[Route("{id}")]
		public async Task<MyResponse<StoreModel>> FindById(int id)
		{
			return await storeLogic.FindById(id);
		}

		[HttpPatch]
		public async Task<MyResponse<bool>> Update(StoreModel model)
		{
			return await storeLogic.Update(model);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<MyResponse<bool>> Delete(int id)
		{
			return await storeLogic.Delete(id);
		}
	}
}
