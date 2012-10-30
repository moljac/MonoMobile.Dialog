using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using MonoMobile.Dialog;
using Android.App;


namespace DialogSampleApp
{
	public partial class RootElementFactory
	{
		static Activity activity = null;

		protected static void StartNew()
		{
			activity.StartActivity(typeof(Activity2));

			return;
		}

	}
}