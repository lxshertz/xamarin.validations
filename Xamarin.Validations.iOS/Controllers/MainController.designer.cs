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

namespace Xamarin.Validations.iOS.Controllers
{
	[Register ("MainController")]
	partial class MainController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		Xamarin.Validations.iOS.Views.ValidationTextView NameValidationView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SubmitButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (NameValidationView != null) {
				NameValidationView.Dispose ();
				NameValidationView = null;
			}
			if (SubmitButton != null) {
				SubmitButton.Dispose ();
				SubmitButton = null;
			}
		}
	}
}
