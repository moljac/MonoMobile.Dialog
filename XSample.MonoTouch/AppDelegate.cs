using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;


using MonoMobile.Dialog;

namespace XSample.MonoTouch
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
		
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			RootElement re = 
				// sample from  MA.D
				DialogSampleApp.UserInterface.UIDefine()
				// sample from  MT.D
				//DialogSampleApp.UserInterface.UI()
				;

			UINavigationController navigation;
			navigation = new UINavigationController();

			//
			// Create our UI and add it to the current toplevel navigation controller
			// this will allow us to have nice navigation animations.
			//
			DialogViewController dv = new DialogViewController(re)
			{
				Autorotate = true
			};

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

