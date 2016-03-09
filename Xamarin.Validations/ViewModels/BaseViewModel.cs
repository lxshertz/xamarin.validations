using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xamarin.Validations.Validations;

namespace Xamarin.Validations.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IValidableModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsValid
        {
            get
            {
                return this.GetValidableProperties()
                  .Select(p => p.GetValue(this) as IValidableProperty)
                  .All(p => p.IsValid);
            }
        }

        public IEnumerable<string> Errors
        {
            get
            {
                return this.GetValidableProperties()
                  .Select(p => p.GetValue(this) as IValidableProperty)
                  .SelectMany(p => p.Errors);
            }
        }

        public virtual bool Validate()
        {
            var allProperties = this.GetValidableProperties()
                .Select(p => p.GetValue(this) as IValidableProperty);

            foreach (var prop in allProperties)
            {
                prop.Validate();
            }

            this.OnPropertyChanged(nameof(this.IsValid));
            return this.IsValid;
        }

        public virtual void RegisterValidationRules()
        {
            var allProperties = this.GetValidableProperties().Select(p => p.GetValue(this) as IValidableProperty);

            foreach (var prop in allProperties)
            {
                prop.PropertyChanged -= this.ValidationPropertyChanged;
                prop.PropertyChanged += this.ValidationPropertyChanged;
            }
        }

        private void ValidationPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IValidableProperty.IsValid))
            {
                this.OnPropertyChanged(nameof(this.IsValid));
            }
            else if(e.PropertyName == nameof(IValidableProperty.Errors))
            {
                this.OnPropertyChanged(nameof(this.Errors));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private IEnumerable<PropertyInfo> GetValidableProperties()
        {
            return
                this.GetType()
                    .GetRuntimeProperties()
                    .Where(t => typeof(IValidableProperty).GetTypeInfo().IsAssignableFrom(t.PropertyType.GetTypeInfo()));
        }
    }
}
