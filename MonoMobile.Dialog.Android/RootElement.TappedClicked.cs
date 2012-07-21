using System;
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace MonoMobile.Dialog
{
	//mc++: following code snippet is from MT.D

	// mc++  is lazy so find/replace is too much work!
	using NSAction = Action;

	public partial class RootElement 
	{
		public RootElement(string caption, NSAction tapped)
			: base(caption)
		{
			Tapped += tapped;
		}

		public event NSAction Tapped;
	}
}