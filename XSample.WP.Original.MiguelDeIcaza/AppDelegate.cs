//
// Shows how to add/remove cells dynamically.
//

using System;
using System.Windows.Controls;

using MonoMobile.Dialog;

namespace Sample
{
	public partial class AppDelegate
	{

		// UINavigationController navigation;
		DialogNavigationControllerAdapter navigation;

		// UIWindow window;
		StackPanel window;


		/*
			//--------------------------------------------------------------------------
			//
			// Create our UI and add it to the current toplevel navigation controller
			// this will allow us to have nice navigation animations.
			//
			var dv = new DialogViewController (menu) {
				Autorotate = true
			};
			navigation = new UINavigationController ();
			navigation.PushViewController (dv, true);				
			
			// On iOS5 we use the new window.RootViewController, on older versions, we add the subview
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			if (UIDevice.CurrentDevice.CheckSystemVersion (5, 0))
				window.RootViewController = navigation;	
			else
				window.AddSubview (navigation.View);

		 * 
			//--------------------------------------------------------------------------
		 
			DialogAdapter da = new DialogAdapter(this, root);

			ListView lv = new ListView(this) {Adapter = da};

			SetContentView(lv);
			//--------------------------------------------------------------------------
		 
		
		 */

		public bool FinishedLaunchingFake ()
		{
			string p = "";
			var menu = new RootElement ("Demos"){
				new Section ("Element API"){
					new StringElement ("Element API HolisticWare", DemoElementApiHolisticWare),
					// new StringElement ("iPhone Settings Sample", DemoElementApi),
					// new StringElement ("Dynamically load data", DemoDynamic),
					// new StringElement ("Add/Remove demo", DemoAddRemove),
					// new StringElement ("Assorted cells", DemoDate),
					// new StyledStringElement ("Styled Elements", DemoStyled) { BackgroundUri = new Uri ("file://" + p) },
					// new StringElement ("Load More Sample", DemoLoadMore),
					// new StringElement ("Row Editing Support", DemoEditing),
					// new StringElement ("Advanced Editing Support", DemoAdvancedEditing),
					// new StringElement ("Owner Drawn Element", DemoOwnerDrawnElement),
				},
				new Section ("Container features"){
					// new StringElement ("Pull to Refresh", DemoRefresh),
					// new StringElement ("Headers and Footers", DemoHeadersFooters),
					// new StringElement ("Root Style", DemoContainerStyle),
					// new StringElement ("Index sample", DemoIndex),
				}
				//, new Section ("Json") {
				// 	(Element) (sampleJson = JsonElement.FromFile ("sample.json")),
				// 	// Notice what happens when I close the paranthesis at the end, in the next line:
				// 	(Element) new JsonElement ("Load from URL", "file://" + Path.GetFullPath ("sample.json"))
				// },
				// new Section ("Auto-mapped", footer){
				// 	new StringElement ("Reflection API", DemoReflectionApi)
				// }
			};

			return true;
		}

	}


}
