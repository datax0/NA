using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace NA.Remittance
{
	partial class SiginViewController : BaseController
	{
		public SiginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.

			var tap = new UITapGestureRecognizer ();
			tap.AddTarget (() => { View.EndEditing (true);
			});
			View.AddGestureRecognizer (tap);
		}
	}
}
