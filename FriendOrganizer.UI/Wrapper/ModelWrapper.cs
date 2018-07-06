using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FriendOrganizer.UI.Wrapper
{
    public class ModelWrapper<T> : NotifyDataErrorInfoBase
    {
        public T Model { get; }
        public ModelWrapper(T model)
        {
            Model = model;
        }
        protected virtual TValue GetValue<TValue>([CallerMemberName]string propertyName = null)
        {
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
        }

        protected virtual void SetValue<TValue>(TValue value, [CallerMemberName]string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(Model, value);
            OnPropertyChanged();
            ValidatePropertyInternal(propertyName,value);
        }

        private void ValidatePropertyInternal(string propertyName,object currentValue)
        {
            ClearError(propertyName);
            ValidateDataAnnotation(propertyName, currentValue);
            CustomValidation(propertyName);
        }

        private void CustomValidation(string propertyName)
        {
            var error = ValidateProperty(propertyName);
            if (error != null)
            {
                foreach (var item in error)
                {
                    AddError(propertyName, item);
                }
            }
        }

        private void ValidateDataAnnotation(string propertyName, object currentValue)
        {
            var context = new ValidationContext(Model) { MemberName = propertyName };
            var result = new List<ValidationResult>();
            Validator.TryValidateProperty(currentValue, context, result);

            foreach (var item in result)
            {
                AddError(propertyName, item.ErrorMessage);

            }
        }

        protected virtual IEnumerable<string> ValidateProperty(string propertyName)
        {
            return null;
        }
    }
}
