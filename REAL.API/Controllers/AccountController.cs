using REAL.API.Authentication;
using REAL.Common;
using REAL.Common.models;
using REAL.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace REAL.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class AccountController : ControllerBase
	{		
		private AccountLogic accountLogic;
		private MyConfig config;
		public AccountController(AccountLogic accountLogic, MyConfig config)
		{
			this.accountLogic = accountLogic;
			this.config = config;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("[action]")]
		public async Task<MyResponse<AccountModel>> Login(LoginModel loginForm)
		{
			return await accountLogic.Login(loginForm, (usr, roles) => {
				usr.Token = TokenAuth.GenerateToken(config, usr.Id.ToString(), roles);
				return usr;
			});
		}
	}
}
