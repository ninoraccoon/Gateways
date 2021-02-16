using Domain.Domain;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace EntityFrameworkCore
{
    public class GatewayContext : DbContext
    {
        public GatewayContext(string connString) : base(connString)
        {
        }

        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Peripheral> Peripherals { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Peripheral>()
            .HasRequired<Gateway>(s => s.Gateway)
            .WithMany(g => g.Peripheral)
            .HasForeignKey<int>(s => s.GatewayId);

           modelBuilder.Entity<Gateway>()
              .HasMany<Peripheral>(s => s.Peripheral)
              .WithRequired(s => s.Gateway)
              .HasForeignKey<int>(s => s.GatewayId);
        }
    }
   
}
