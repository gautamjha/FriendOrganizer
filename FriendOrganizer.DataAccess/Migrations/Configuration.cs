namespace FriendOrganizer.DataAccess.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friend.AddOrUpdate(x => x.FirstName,
                 new Friend { FirstName = "Thommas", LastName = "Huber", Email = "gautam21jha@gmail.com" },
                  new Friend { FirstName = "Julia", LastName = "Huber", Email = "gautam21jha@gmail.com" },
                   new Friend { FirstName = "John", LastName = "Huber", Email = "gautam21jha@gmail.com" });
        }
    }
}
