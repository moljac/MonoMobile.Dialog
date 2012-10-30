using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class StringElement
		: Element
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Constructors

		public override string Summary()
		{
			Caption = Value;

			return Caption;   // MT.D
			//return Value;	  // MA.D
		}

		public override bool Matches(string text)
		{
			return 
				(Value != null ? Value.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) != -1 : false) 
				||
				base.Matches(text)
				;
		}
	}
}