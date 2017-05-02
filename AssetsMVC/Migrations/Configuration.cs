namespace AssetsMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assets_MVC_.Models.AssetsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assets_MVC_.Models.AssetsDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.mas_Accessory.AddOrUpdate(m => m.accessory,
                new Assets_MVC_.Models.mas_accessory { accessory = "CPU", active = true },
                new Assets_MVC_.Models.mas_accessory { accessory = "MONITOR", active = true },
                new Assets_MVC_.Models.mas_accessory { accessory = "MOUSE", active = true },
                new Assets_MVC_.Models.mas_accessory { accessory = "KEYBOARD", active = true }
                );
        }
    }
}
