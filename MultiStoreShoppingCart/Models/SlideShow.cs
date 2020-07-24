

using MultiStoreShoppingCart.Repositories.EFCore;
using System;
using System.Collections.Generic;

namespace MultiStoreShoppingCart.Models
{
    public partial class SlideShow : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
