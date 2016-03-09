using System.Collections.Generic;

namespace Xamarin.Validations.Validations
{
    public interface IValidableModel
    {
        bool IsValid { get; }

        IEnumerable<string> Errors { get; }

        bool Validate();

        void RegisterValidationRules();
    }
}
