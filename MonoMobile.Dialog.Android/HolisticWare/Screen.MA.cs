using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MonoMobile.Dialog;
using Android.Widget;

namespace MonoMobile.Dialog
{
	/// <summary>
	/// </summary>
	public partial class Screen
		:
		Android.App.Activity
	{
		public void Navigate(RootElement root_element_next_screen)
		{
			DialogAdapter da = new DialogAdapter(this, root_element_next_screen);
			ListView lv = new ListView(this)
			{
				Adapter = da
			};
			this.SetContentView(lv);

			return;
		}

	}
}
