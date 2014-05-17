using MonoTouch.UIKit;
using System;
using MonoTouch.Foundation;
using System.Linq;
using System.Collections.Generic;
using MonoTouch.Dialog;

using FlyoutNavigation;

namespace NA.Remittance
{
	public partial class MainViewController : BaseController
	{

		FlyoutNavigationController navigation;

		// Data we'll use to create our flyout menu and views:
		string[] Tasks = {
			"Get Xamarin",
			"Learn C#",
			"Write Killer App",
			"Add Platforms",
			"Profit",
			"Meet Obama",
		};
		public MainViewController () : base ()
		{
			// Custom initialization
		}
		public MainViewController (IntPtr handle) : base (handle)
		{
			// Custom initialization
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			/*
			// Create the flyout view controller, make it large,
			// and add it as a subview:
			navigation = new FlyoutNavigationController ();
			navigation.View.Frame = UIScreen.MainScreen.Bounds;
			View.AddSubview (navigation.View);

			// Create the menu:
			navigation.NavigationRoot = new RootElement ("Task List") {
				new Section ("Task List") {
					from page in Tasks
					select new StringElement (page) as Element
				}
			};

			// Create an array of UINavigationControllers that correspond to your
			// menu items:
			navigation.ViewControllers = Array.ConvertAll (Tasks, title =>
				new UINavigationController (new TaskPageController (navigation, title))
			);
			*/

			var navigation = new FlyoutNavigationController {
				// Create the navigation menu
				NavigationRoot = new RootElement ("Navigation") {
					new Section ("Pages") {
						new StringElement ("Animals"),
						new StringElement ("Vegetables"),
						new StringElement ("Minerals"),
					}
				},
				// Supply view controllers corresponding to menu items:
				ViewControllers = new [] {
					new UIViewController { View = new UILabel { Text = "Animals (drag right)" } },
					new UIViewController { View = new UILabel { Text = "Vegetables (drag right)" } },
					new UIViewController { View = new UILabel { Text = "Minerals (drag right)" } },
				},
			};
			// Show the navigation view
			navigation.ToggleMenu ();
			View.AddSubview (navigation.View);
			// Perform any additional setup after loading the view, typically from a nib.

			var tap = new UITapGestureRecognizer ();
			tap.AddTarget (() => { View.EndEditing (true);
			});
			View.AddGestureRecognizer (tap);


		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

	
	}

	class TaskPageController : DialogViewController
	{
		public TaskPageController (FlyoutNavigationController navigation, string title) : base (null)
		{
			Root = new RootElement (title) {
				new Section {
					new CheckboxElement (title)
				}
			};
			NavigationItem.LeftBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Action, delegate {
				navigation.ToggleMenu ();
			});
		}
	}
}

