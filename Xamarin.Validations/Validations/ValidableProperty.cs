using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Xamarin.Validations.Validations
{
    public class ValidableProperty<T> : IValidableProperty
    {
        private readonly List<ValidationRule> validations;

        public event PropertyChangedEventHandler PropertyChanged;

        private T value;

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (!EqualityComparer<T>.Default.Equals(this.value, value))
                {
                    this.value = value;

                    this.Validate();
                    this.OnPropertyChanged();
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return !this.Errors.Any();
            }
        }

        public ObservableCollection<string> Errors { get; private set; }

        public ValidableProperty()
        {
            this.validations = new List<ValidationRule>();
            this.Errors = new ObservableCollection<string>();
        }

        public bool Validate()
        {
            IEnumerable<string> errors = this.validations.Where(v => !v.Check(this.Value)).Select(v => v.ValidationMessage);
            this.Errors.Clear();

            foreach (var error in errors)
            {
                this.Errors.Add(error);
            }

            this.OnPropertyChanged(nameof(this.IsValid));

            return this.IsValid;
        }

        public void AddValidation(ValidationRule rule)
        {
            this.validations.Add(rule);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
