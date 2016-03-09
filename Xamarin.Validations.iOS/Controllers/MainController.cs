using System;
using System.ComponentModel;
using System.Linq;
using UIKit;
using Xamarin.Validations.ViewModels;

namespace Xamarin.Validations.iOS.Controllers
{
    partial class MainController : UIViewController
    {
        private MainViewModel viewModel;

        public MainController (IntPtr handle) : base (handle)
        {
            this.viewModel = new MainViewModel();
            this.viewModel.PropertyChanged += this.ViewModelPropertyChanged;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NameValidationView.TextChanged += NameViewTextChanged;
            this.NameValidationView.FocusLost += NameViewFocusLost;
            this.SubmitButton.TouchUpInside += this.SubmitButtonTouchUpInside;
        }

        private void NameViewTextChanged(object sender, EventArgs e)
        {
            this.ValidateName();
        }

        private void NameViewFocusLost(object sender, EventArgs e)
        {
            this.ValidateName();
        }

        private void SubmitButtonTouchUpInside(object sender, EventArgs e)
        {
            this.viewModel.Name.Value = this.NameValidationView.Text;
            this.viewModel.SaveCommand.Execute(null);
        }

        private void ValidateName()
        {
            this.viewModel.Name.Value = this.NameValidationView.Text;
            this.NameValidationView.ErrorText = this.viewModel.Name.Errors.FirstOrDefault();
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainViewModel.IsValid))
            {
                this.SubmitButton.Enabled = this.viewModel.IsValid;

                if (!this.viewModel.IsValid)
                {
                    this.ValidateName();
                }
            }
        }
    }
}
