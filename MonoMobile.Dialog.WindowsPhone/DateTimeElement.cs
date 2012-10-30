using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class DateTimeElement
		: StringElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public DateTime DateValue
		{
			get { return DateTime.Parse(Value); }
			set { Value = Format(value); }
		}
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public DateTimeElement(string caption, DateTime date)
			: base(caption)
		{
			DateValue = date;
			Value = FormatDate(date);
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

	}
}