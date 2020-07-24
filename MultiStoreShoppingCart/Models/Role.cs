

using MultiStoreShoppingCart.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiStoreShoppingCart.Models
{
    public partial class Role: IEntity
    {
        public Role()
        {
            Account = new HashSet<Account>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Account> Account { get; set; }
    }
}
