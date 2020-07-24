
using MultiStoreShoppingCart.Models;
using MultiStoreShoppingCart.Repositories.EFCore;

namespace MultiStoreShoppingCart.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public Account Login(string username, string password, int roleId);
        public Account getByUsername(string username);
    }
}
