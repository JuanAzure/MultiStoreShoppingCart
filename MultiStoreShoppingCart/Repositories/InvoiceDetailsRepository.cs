using MultiStoreShoppingCart.Models;
using MultiStoreShoppingCart.Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiStoreShoppingCart.Repositories
{
    public class InvoiceDetailsRepository : GenericRepository<InvoiceDetails>, IInvoiceDetailsRepository
    {
        public InvoiceDetailsRepository(DatabaseContext dbcontext) : base(dbcontext)
        {
        }
    }
}
