using FriendOrganizer.UI.Data;
using System.Threading.Tasks;
using Prism.Events;
using FriendOrganizer.UI.Event;
using System.Windows.Input;
using Prism.Commands;
using FriendOrganizer.UI.Wrapper;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendDataService _dataservice;
        private IEventAggregator _eventAggregator;
        private FriendWrapper _friend;
        public FriendDetailViewModel(IFriendDataService dataservice, IEventAggregator eventAggregator)
        {
            _dataservice = dataservice;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnFreindSelectionChanged);
            SaveCommand = new DelegateCommand(onSaveExecute, OnSaveCanExecute);
        }
        public async Task LoadAsync(int friendId)
        {
            var tempfreind = await _dataservice.GetByIdAsync(friendId);
            Friend = new Wrapper.FriendWrapper(tempfreind);

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

        }
        public FriendWrapper Friend
        {
            get
            {
                return _friend;
            }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }
        public ICommand SaveCommand { get; }
        private bool OnSaveCanExecute()
        {
            return Friend != null && Friend.HasErrors;
        }
        private async void onSaveExecute()
        {
           await _dataservice.SaveFriendAsync(Friend.Model);

            _eventAggregator.GetEvent<AfterFriendSaveEvent>().Publish
                 (new AfterFriendSaveEventArgs
                   {
                     Id=Friend.Id,
                     DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
                 });
                
        }
        private async void OnFreindSelectionChanged(int FriendId)
        {
           await LoadAsync(FriendId);
        }
    }
}
