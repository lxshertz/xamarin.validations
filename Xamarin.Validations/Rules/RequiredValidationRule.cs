using Xamarin.Validations.Validations;

namespace Xamarin.Validations.Rules
{
    public class RequiredValidationRule : ValidationRule
    {
        public override bool Check(object value)
        {
            var str = value as string;

            return !string.IsNullOrEmpty(str);
        }
    }
}
