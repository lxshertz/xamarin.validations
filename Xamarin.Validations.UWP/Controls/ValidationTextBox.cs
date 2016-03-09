using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Xamarin.Validations.UWP.Controls
{
    public class ValidationTextBox : TextBox
    {
        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.Register("IsValid", typeof(bool), typeof(ValidationTextBox), new PropertyMetadata(true));

        public bool IsValid
        {
            get { return (bool)this.GetValue(IsValidProperty); }
            set { this.SetValue(IsValidProperty, value); }
        }

        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(ValidationTextBox), null);

        public string ErrorMessage
        {
            get { return (string)this.GetValue(ErrorMessageProperty); }
            set { this.SetValue(ErrorMessageProperty, value); }
        }

        public ValidationTextBox()
        {
            this.DefaultStyleKey = typeof(ValidationTextBox);
        }
    }
}
