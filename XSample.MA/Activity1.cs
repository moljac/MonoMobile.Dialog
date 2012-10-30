using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

using System;

using MonoMobile.Dialog;

namespace MonoMobile.XSample
{
	//
	// NOTE: with the new update you will have to add all the dialog_* prefixes to your main application.
	//       This is because the current version of Mono for Android will not add resources from assemblies
	//       to the main application like it does for libraries in Android/Java/Eclipse...  This could
	//       change in a future version (it's slated for 1.0 post release) but for now, just add them 
	//       as in this sample...
	//
	[Activity(Label = "MD.D Sample", MainLauncher = true, WindowSoftInputMode = SoftInput.AdjustPan)]
	public class Activity1 : Activity
	{
		protected void StartNew()
		{
			StartActivity(typeof(Activity2));
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			UserInterface.a1 = this;

			RootElement root =
				//DialogSampleApp.UserInterface.UIDefine()
				//UserInterface.UICities()
				UserInterface.TestElements()
				;

			var da = new DialogAdapter(this, root);

			var lv = new ListView(this) {Adapter = da};

			SetContentView(lv);
		}
	}
}