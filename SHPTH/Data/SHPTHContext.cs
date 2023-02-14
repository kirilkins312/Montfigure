using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SHPTH.Models;

namespace SHPTH.Data
{
    public class SHPTHContext : IdentityDbContext<ApplicationUser>
    {
        public SHPTHContext (DbContextOptions<SHPTHContext> options)
            : base(options)
        {
        }

        public DbSet<SHPTH.Models.Cloth> Cloth { get; set; } = default!;

        public DbSet<SHPTH.Models.Order.Order> Orders { get; set; } = default!;
        public DbSet<SHPTH.Models.Order.OrderItem> OrderItems { get; set; } = default!;
        public DbSet<SHPTH.Models.Order.ShoppingCartItem> ShoppingCartItems { get; set; } = default!;
        public DbSet<SHPTH.Models.Categories.SizeSeparation> SizeSeparations { get; set; } = default!;
        public DbSet<SHPTH.Models.Categories.ClothSeparation> ClothSeparation { get; set; } = default!;

    }
}
