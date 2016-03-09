namespace Xamarin.Validations.Validations
{
    public abstract class ValidationRule
    {
        public string ValidationMessage { get; set; }

        public abstract bool Check(object value);
    }
}
