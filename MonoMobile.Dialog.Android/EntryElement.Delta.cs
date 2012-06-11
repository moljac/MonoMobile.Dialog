using System;
using Android.Content;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.App;

namespace MonoMobile.Dialog
{	
	public partial class EntryElement
	{
		bool isPassword, becomeResponder;
		string placeholder;

		public EntryElement(string caption, string placeholder, string value, bool isPassword)
			: this(caption, value)
		{
			Value = value;
			this.isPassword = isPassword;
			this.placeholder = placeholder;

			return;
		}
	}
}