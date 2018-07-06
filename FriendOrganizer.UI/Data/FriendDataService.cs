using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class FriendDataService:IFriendDataService
    {
       private Func<FriendOrganizerDbContext> _ContextCreator;

        public FriendDataService(Func<FriendOrganizerDbContext> ContextCreator)
        {
            _ContextCreator = ContextCreator;

        }
       public async Task<Friend> GetByIdAsync(int FriendId)
        {
            using (var ctx= _ContextCreator())
            {
                return await ctx.Friend.AsNoTracking().SingleAsync(x => x.Id == FriendId);
            }
           
        }

        public async Task SaveFriendAsync(Friend objFriend)
        {
            using (var ctx = _ContextCreator())
            {
                ctx.Friend.Attach(objFriend);
                ctx.Entry(objFriend).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }
     
    }
}
