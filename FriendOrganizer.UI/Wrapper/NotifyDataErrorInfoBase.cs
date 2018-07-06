using FriendOrganizer.UI.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Wrapper
{
    public class NotifyDataErrorInfoBase : ViewModelBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> errorByPropertyName = new Dictionary<string, List<string>>();

        public bool HasErrors => errorByPropertyName.Any();


        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return errorByPropertyName.ContainsKey(propertyName) ? errorByPropertyName[propertyName] : null;
        }

        protected virtual void onErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void AddError(string propertyName, string error)
        {
            if (!errorByPropertyName.ContainsKey(propertyName))
            {
                errorByPropertyName[propertyName] = new List<string>();
            }
            if (!errorByPropertyName[propertyName].Contains(error))
            {
                errorByPropertyName[propertyName].Add(error);
            }
            onErrorChanged(propertyName);
        }
        protected void ClearError(string propertyName)
        {
            if (errorByPropertyName.ContainsKey(propertyName))
            {
                errorByPropertyName.Remove(propertyName);
                onErrorChanged(propertyName);
            }

        }

    }
}
