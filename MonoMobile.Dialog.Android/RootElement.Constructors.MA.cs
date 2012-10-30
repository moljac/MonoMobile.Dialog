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
		// RootElement to mimic back like in MonoTouch
		private RootElement root_element_navigate_back;

		public RootElement(string caption, RootElement navigate_back)
			: this(caption)
		{
			this.Add(new StringElement("Back", BackClicked));

			return;
		}

		protected virtual void BackClicked()
		{
			return;
		}
	}
}