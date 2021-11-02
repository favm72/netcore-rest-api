using REAL.Logic.interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace REAL.API
{
	public class UserResolverService : IUserResolverService
	{
		private readonly IHttpContextAccessor _context;
		public UserResolverService(IHttpContextAccessor context)
		{
			_context = context;
		}

		public int GetUserId()
		{
			try
			{
				return int.Parse(_context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
			}
			catch (Exception)
			{
				throw new Exception("Error al capturar usuario.");
			}
		}

		public bool HasRole(string role)
		{
			try
			{
				return _context.HttpContext.User.IsInRole(role);
			}
			catch (Exception)
			{
				throw new Exception("Error al consultar rol.");
			}
		}
	}
}
