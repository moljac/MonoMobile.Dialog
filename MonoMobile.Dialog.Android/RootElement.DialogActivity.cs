using System;
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace MonoMobile.Dialog
{
	public partial class RootElement 
	{
		// Added to enable nested RootElements without explicit Activities
		MonoMobile.Dialog.DialogActivity activity = new DialogActivity();

		public void StartActivity(System.Type type_of_activity)
		{
			ActivityMonoMobileDialog ammd = new ActivityMonoMobileDialog();
			ammd.StartActivity(type_of_activity);

			return;
		}
	}
}