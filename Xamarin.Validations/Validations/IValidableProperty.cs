using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Xamarin.Validations.Validations
{
    public interface IValidableProperty : INotifyPropertyChanged
    {
        bool IsValid { get; }

        ObservableCollection<string> Errors { get; }

        void AddValidation(ValidationRule rule);

        bool Validate();
    }
}
