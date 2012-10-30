using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace MonoMobile.Dialog
{
	public abstract partial class BoolElement : Element
	{

		# region    Constructors
		//-------------------------------------------------------------------------
		protected BoolElement(string caption, bool value, int layoutId)
			: base(caption, layoutId)
		{
			val = value;
		}
		//-------------------------------------------------------------------------
		protected BoolElement(string caption, bool value, string key, int layoutId)
			: base(caption, layoutId)
		{
			val = value;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors
	
		
	}
}