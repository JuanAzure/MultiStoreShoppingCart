
using MultiStoreShoppingCart.Models;
using MultiStoreShoppingCart.Repositories.EFCore;

namespace MultiStoreShoppingCart.Repositories
{
    public interface IMembershipRepository : IGenericRepository<Membership>
    {
    }
}
