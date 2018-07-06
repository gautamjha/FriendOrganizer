using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
   public class MainViewModel:ViewModelBase
    {
        public INavigationViewModel navigationViewModel { get; }
        public IFriendDetailViewModel friendDetailViewModel { get; }
        public MainViewModel(INavigationViewModel _navigationViewModel, IFriendDetailViewModel _friendDetailViewModel)
        {
            navigationViewModel = _navigationViewModel;
            friendDetailViewModel = _friendDetailViewModel;
        }

        public async Task LoadAsync()
        {
            await navigationViewModel.LoadAsync();
        }
    }
  
}
