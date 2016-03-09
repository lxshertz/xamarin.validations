using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Text;
using Android.Views;
using Android.Widget;
using System;
using System.Linq;
using Xamarin.Validations.ViewModels;

namespace Xamarin.Validations.Android
{
    [Activity(Label = "Xamarin.Validations.Android", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Xamarin.Validations")]
    public class MainActivity : Activity
    {
        private readonly MainViewModel viewModel;
        private TextInputLayout nameEditInput;
        private Button submitButton;

        public MainActivity()
        {
            this.viewModel = new MainViewModel();
            this.viewModel.PropertyChanged += this.ViewModelPropertyChanged;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            this.InitializeViews();
        }

        private void InitializeViews()
        {
            var contentView = this.FindViewById<LinearLayout>(Resource.Id.main);

            this.nameEditInput = contentView.FindViewById<TextInputLayout>(Resource.Id.main_form_name_input);
            this.nameEditInput.EditText.FocusChange += this.NameFocusChange;
            this.nameEditInput.EditText.TextChanged += this.NameTextChanged;

            this.submitButton = contentView.FindViewById<Button>(Resource.Id.main_form_submit);
            this.submitButton.Click += this.SubmitButtonClick;
        }

        private void NameTextChanged(object sender, TextChangedEventArgs e)
        {
            this.ValidateName();
        }

        private void NameFocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                this.nameEditInput.ErrorEnabled = false;
            }
            else
            {
                this.ValidateName();
            }
        }

        private void SubmitButtonClick(object sender, EventArgs e)
        {
            this.viewModel.Name.Value = this.nameEditInput.EditText.Text;
            this.viewModel.SaveCommand.Execute(null);
        }

        private void ValidateName()
        {
            this.viewModel.Name.Value = this.nameEditInput.EditText.Text;
            this.nameEditInput.Error = this.viewModel.Name.Errors.FirstOrDefault();
        }

        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainViewModel.IsValid))
            {
                this.submitButton.Enabled = this.viewModel.IsValid;

                if (!this.viewModel.IsValid)
                {
                    this.ValidateName();
                }
            }
        }
    }
}

