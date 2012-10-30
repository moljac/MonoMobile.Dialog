using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class DateElement 
		:
		DateTimeElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public DateElement(string caption, DateTime date)
			: base(caption, date)
		{
		}
		//-------------------------------------------------------------------------
		# endregion Constructors
	}
}