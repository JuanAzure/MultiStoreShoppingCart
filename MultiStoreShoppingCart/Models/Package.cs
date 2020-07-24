

using MultiStoreShoppingCart.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiStoreShoppingCart.Models
{
    public partial class Package: IEntity
    {
        public Package()
        {
            Membership = new HashSet<Membership>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<Membership> Membership { get; set; }
    }
}
