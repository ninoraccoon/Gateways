using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Text;

namespace EntityFrameworkCore.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GatewayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GatewayContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
