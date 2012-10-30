using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class HtmlElement
	{
		System.Uri uri_netfx = null;

		# region    Properites
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public HtmlElement(string caption, System.Uri u)
			: base(caption)
		{
			uri_netfx = u;
			this.Url = u.ToString();
		}
		//-------------------------------------------------------------------------
		# endregion Constructors
	}
}