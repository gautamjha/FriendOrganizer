using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class LookupDataService : IFriendLookupDataService
    {
        private Func<FriendOrganizerDbContext> creator;

        public LookupDataService(Func<FriendOrganizerDbContext> _creator)
        {
            creator = _creator;
        }
        public async Task<IEnumerable<LookupItem>> GetFrienlookupAsync()
        {
            using (var ctx = creator())
            {
                return await ctx.Friend.AsNoTracking().Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.FirstName + " " + f.LastName
                  }).ToListAsync();
                    
            }
        }
    }
}
