using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
   public interface IFriendDataService
    {
         Task<Friend> GetByIdAsync(int FriendId);

        Task SaveFriendAsync(Friend objFriend);
    }
}
