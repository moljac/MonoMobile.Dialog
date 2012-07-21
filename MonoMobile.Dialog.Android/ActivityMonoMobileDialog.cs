using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using MonoMobile.Dialog;

namespace MonoMobile.Dialog
{
	[Activity(Label = "MonoMobile.Dialog DialogActivity")]
	public partial class ActivityMonoMobileDialog 
		: 
		Android.App.Activity
		// mc++: MonoAndroid.Dialog by KevinMcMahon 
		// DialogActivity does not inherit form Android.App.Activity,
		// so StartActivity cannot be called
	{
		protected DialogViewController dialog_view_controller;
		protected DialogAdapter dialog_adapter;
		protected ListView list_view;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			dialog_view_controller = new DialogViewController();

			return;
		}

		public void ReDraw(RootElement re)
		{
			// MonoMobile.Dialog app creation

			this.Title = re.Caption;

			// mc++: equivalent to MonoTouchDialog.DialogViewController
			dialog_adapter = new DialogAdapter(this, re);
			// mc++: equivalent to MonoTouch UINavigationController
			list_view = new ListView(this) 
								{
								  Adapter = dialog_adapter
								};

			// mc++: equivalent to MonoTouch Window
			// Activity.SetContentView ~ Window.RootViewController	iOS 5+
			// Activity.SetContentView ~ Window.AddSubview			iOS other
			SetContentView(list_view);

			return;
		}

		public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
		{
			if (keyCode == Keycode.Back)
			{
				// your staff here:
				Toast.MakeText(this, "back!", ToastLength.Short).Show();

				return base.OnKeyDown(keyCode, e);

				return true;
			}

			return true;
		}
	}
}