// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Xamarin.Validations.iOS
{
	[Register ("ValidationTextView")]
	partial class ValidationTextView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ErrorLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField TextField { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ErrorLabel != null) {
				ErrorLabel.Dispose ();
				ErrorLabel = null;
			}
			if (TextField != null) {
				TextField.Dispose ();
				TextField = null;
			}
		}
	}
}
