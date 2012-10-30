using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class BoolElement : Element
	{

		# region    Properites
		//-------------------------------------------------------------------------
		bool val;
		public virtual bool Value
		{
			get
			{
				return val;
			}
			set
			{
				bool emit = val != value;
				val = value;
				if (emit && ValueChanged != null)
					ValueChanged(this, EventArgs.Empty);
			}
		}
		public event EventHandler ValueChanged;
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites


		# region    Constructors
		//-------------------------------------------------------------------------
		public BoolElement(string caption, bool value)
			: base(caption)
		{
			val = value;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

		public override string Summary()
		{
			return val ? "On".GetText() : "Off".GetText();
		}
	}
}