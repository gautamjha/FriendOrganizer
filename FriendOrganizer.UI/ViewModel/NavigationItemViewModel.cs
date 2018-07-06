using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel:ViewModelBase
    {
        public int Id { get; set; }
        private string displaymember;

        public NavigationItemViewModel(int _Id,String _DisplayMember)
        {
            Id = _Id;
            displaymember = _DisplayMember;


        }
        public string DisplayMember
        {
            get { return displaymember; }
            set
            {
                displaymember = value;
                OnPropertyChanged();
            }
        }

    }
}
