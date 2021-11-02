namespace REAL.Logic.interfaces
{
	public interface IUserResolverService
	{
		int GetUserId();
		bool HasRole(string role);
	}
}