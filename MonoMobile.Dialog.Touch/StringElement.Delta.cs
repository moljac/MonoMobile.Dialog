using System;

namespace MonoMobile.Dialog
{	
	public partial class StringElement
	{
		public StringElement(string caption, string value, Action clicked)
			: this(caption, value)
		{
			Value = value;

			//
			//this.Tapped = clicked;

			return;
		}
	}
}