using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;
using MonoTouch.Foundation;

using MonoMobile.Dialog.Utilities;
using MonoTouch.CoreAnimation;

namespace MonoMobile.Dialog
{
	public partial class CheckboxElement : StringElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public CheckboxElement(string caption, bool value, string subcaption, string group)
			: this(subcaption, value)
		{
			this.Group = group;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

	}

}