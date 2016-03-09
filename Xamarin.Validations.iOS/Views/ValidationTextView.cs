using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using UIKit;

namespace Xamarin.Validations.iOS.Views
{
    [DesignTimeVisible(true)]
    partial class ValidationTextView : UIView, IComponent
    {
        public event EventHandler Disposed;
        public event EventHandler TextChanged;
        public event EventHandler FocusLost;

        public ISite Site { get; set; }

        public string Text
        {
            get
            {
                return this.TextField.Text;
            }

            set
            {
                this.TextField.Text = value;
            }
        }

        public string ErrorText
        {
            get
            {
                return this.ErrorMessageLabel.Text;
            }

            set
            {
                this.ErrorMessageLabel.Text = value;
            }
        }

        public ValidationTextView()
        {
            this.Initialize();
        }

        public ValidationTextView(IntPtr handle) : base(handle)
        {
        }

        public override void AwakeFromNib()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            var arr = NSBundle.MainBundle.LoadNib("ValidationTextView", this, null);
            var v = Runtime.GetNSObject<UIView>(arr.ValueAt(0));

            this.Add(v);
            this.TextField.EditingChanged += this.TextFieldChanged;
            this.TextField.EditingDidEnd += this.TextFieldEditingDidEnd;

            this.NeedsUpdateConstraints();
        }

        private void TextFieldEditingDidEnd(object sender, EventArgs e)
        {
            this.FocusLost?.Invoke(this, new EventArgs());
        }

        private void TextFieldChanged(object sender, EventArgs e)
        {
            this.TextChanged?.Invoke(this, new EventArgs());
        }
    }
}
