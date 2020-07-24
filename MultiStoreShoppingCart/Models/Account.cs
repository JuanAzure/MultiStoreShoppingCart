

using MultiStoreShoppingCart.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiStoreShoppingCart.Models
{
    public partial class Account:IEntity
    {
        public Account()
        {
            Invoice = new HashSet<Invoice>();
            Membership = new HashSet<Membership>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? RoleId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhone { get; set; }
        public string StoreWebSite { get; set; }
        public string StoreLogo { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Membership> Membership { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
