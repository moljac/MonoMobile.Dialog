using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;


using MonoMobile.Dialog;

namespace MonoMobile.XSample
{
	/// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UINavigationController navigation;
		UIBarButtonItem buttonAdd;
		
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			UINavigationController navigation;
			navigation = new UINavigationController ();

			RootElement re = MonoMobile.XSample.UserInterface.UICities();


			//
			// Create our UI and add it to the current toplevel navigation controller
			// this will allow us to have nice navigation animations.
			//
			DialogViewController dv = new DialogViewController (re)
			{
				Autorotate = true
			};

			int n = 0;
			buttonAdd = new UIBarButtonItem (UIBarButtonSystemItem.Add);
			buttonAdd.Clicked += delegate(object sender, EventArgs e) {
			   
				++n;
			   
				City c = new City{Name = "city " + n};
			   
				RootElement cityElement = new RootElement (c.Name){
			  new Section () {
					  new EntryElement (c.Name,
							 "Enter task description", c.Name)
			  },
			  new Section () {
					  new DateElement ("Due Date", DateTime.Now)
			  }
			};
				//re[0].Add (cityElement);	
			};
			dv.NavigationItem.RightBarButtonItem = buttonAdd;

			navigation.PushViewController(dv, true);

			// On iOS5 we use the new window.RootViewController, on older versions, we add the subview
			window = new UIWindow(UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible();
			if (UIDevice.CurrentDevice.CheckSystemVersion(5, 0))
				window.RootViewController = navigation;
			else
				window.AddSubview(navigation.View);

			return true;
		}

	}
}

