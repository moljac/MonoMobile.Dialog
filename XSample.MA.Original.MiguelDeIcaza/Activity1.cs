using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using MonoMobile.Dialog;
// Miguel's Namespace
using Sample;

namespace XSample.MA.Original.MiguelDeIcaza
{
	[Activity(Label = "XSample.MA.Original.MiguelDeIcaza", MainLauncher = true, Icon = "@drawable/icon")]
	public class Activity1 : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			AppDelegate ad = new AppDelegate();

			RootElement root =
					new AppDelegate().CreateRootHolisticWare()
					// new RootElement("Test Root Elem") { }
					;


			var da = new DialogAdapter(this, root);
			//

			var lv = new ListView(this) { Adapter = da };

			SetContentView(lv);

			return;
		}
	}
}

