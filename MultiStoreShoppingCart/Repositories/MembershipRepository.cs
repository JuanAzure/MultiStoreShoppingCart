﻿using MultiStoreShoppingCart.Models;
using MultiStoreShoppingCart.Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiStoreShoppingCart.Repositories
{
    public class MembershipRepository : GenericRepository<Membership>, IMembershipRepository
    {
        public MembershipRepository(DatabaseContext dbcontext) : base(dbcontext)
        {
        }
    }
}
