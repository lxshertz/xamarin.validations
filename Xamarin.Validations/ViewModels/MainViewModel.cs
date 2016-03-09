using Xamarin.Validations.Rules;
using Xamarin.Validations.Utils;
using Xamarin.Validations.Validations;

namespace Xamarin.Validations.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ValidableProperty<string> name;

        public ValidableProperty<string> Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.OnPropertyChanged();
            }
        }

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                return this.saveCommand;
            }

            set
            {
                this.saveCommand = value;
                this.OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            this.SaveCommand = new RelayCommand(() => this.Save());
            this.Name = new ValidableProperty<string>();
            this.RegisterValidationRules();
        }

        public override void RegisterValidationRules()
        {
            base.RegisterValidationRules();

            this.Name.AddValidation(new RequiredValidationRule { ValidationMessage = "Name is required" });
            this.Name.AddValidation(new LengthValidationRule { MinimunLength = 3, MaximunLength = 20, ValidationMessage = "Name should have between 3 and 20 characters" });
        }

        private void Save()
        {
            this.Validate();

            if (this.IsValid)
            {
                // Some stuff here
            }
        }
    }
}
