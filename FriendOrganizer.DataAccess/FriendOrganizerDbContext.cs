using System.Data.Entity;
using FriendOrganizer.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext:DbContext
    {
        public FriendOrganizerDbContext():base("FriendOrganizerDb")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Friend> Friend { get; set; }
    }
}
