using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IFriendLookupDataService creator;
       private IEventAggregator eventAggregator;
        public ObservableCollection<NavigationItemViewModel> Friends { get; }


        public NavigationViewModel(IFriendLookupDataService _creator,
            IEventAggregator _eventAggregator)
        {
            creator = _creator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            eventAggregator = _eventAggregator;
            eventAggregator.GetEvent<AfterFriendSaveEvent>().Subscribe(AfterFriendSave);
        }

        private void AfterFriendSave(AfterFriendSaveEventArgs obj)
        {
          var tempItem=  Friends.Single(l => l.Id == obj.Id);
            tempItem.DisplayMember = obj.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var friend = await creator.GetFrienlookupAsync();
            Friends.Clear();
            foreach (var item in friend)
            {
                Friends.Add(new ViewModel.NavigationItemViewModel(item.Id,item.DisplayMember ));
            }
        }
        private NavigationItemViewModel _SelectedFriend;

        public NavigationItemViewModel SelectedFriend
        {
            get { return _SelectedFriend; }
            set
            {
                _SelectedFriend = value;
               
                OnPropertyChanged();
                if (_SelectedFriend!=null)
                {
                    eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Publish(SelectedFriend.Id);
                }


            }
        }

    }
}
