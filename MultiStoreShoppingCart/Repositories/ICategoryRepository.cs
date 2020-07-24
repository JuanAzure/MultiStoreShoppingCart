
using MultiStoreShoppingCart.Models;
using MultiStoreShoppingCart.Repositories.EFCore;

namespace MultiStoreShoppingCart.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
