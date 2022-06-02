﻿using DiscountService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountService.Infrastructure.Contexts
{
    public class DiscountDataBaseContext : DbContext
    {
        public DiscountDataBaseContext(DbContextOptions<DiscountDataBaseContext> options)
        : base(options)
        {
        }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
    }
}
