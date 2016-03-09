using Xamarin.Validations.Validations;

namespace Xamarin.Validations.Rules
{
    public class LengthValidationRule : ValidationRule
    {
        public int MinimunLength { get; set; }

        public int MaximunLength { get; set; }

        public override bool Check(object value)
        {
            var str = value as string;

            return !string.IsNullOrEmpty(str)
                ? str.Length >= this.MinimunLength && str.Length <= this.MaximunLength
                : true;
        }
    }
}
