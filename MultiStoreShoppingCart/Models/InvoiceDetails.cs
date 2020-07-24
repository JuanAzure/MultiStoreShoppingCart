
using MultiStoreShoppingCart.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiStoreShoppingCart.Models
{
    public partial class InvoiceDetails:IEntity
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
