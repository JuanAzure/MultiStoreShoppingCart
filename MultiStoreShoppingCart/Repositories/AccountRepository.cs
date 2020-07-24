using MultiStoreShoppingCart.Models;
using MultiStoreShoppingCart.Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiStoreShoppingCart.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(DatabaseContext dbcontext) : base(dbcontext)
        {
        }

        public Account Login(string username, string password, int roleId)
        {
            var account = GetAll()
                .SingleOrDefault(a => a.Username.Equals(username)
                && a.RoleId == roleId && a.Status == true);

            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }

        public Account getByUsername(string username)
        {
            return GetAll().SingleOrDefault(a => a.Username.Equals(username));
        }
    }
}
