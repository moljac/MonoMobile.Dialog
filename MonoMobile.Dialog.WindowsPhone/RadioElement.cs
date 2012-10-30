using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class RadioElement
		: StringElement
	{
		internal int RadioIdx;

		# region    Properites
		//-------------------------------------------------------------------------
		public string Group { get; set; }
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public RadioElement(string caption, string group)
			: base(caption)
		{
			Group = group;
		}
		//-------------------------------------------------------------------------
		public RadioElement(string caption)
			: base(caption)
		{
		}
		//-------------------------------------------------------------------------
		# endregion Constructors
	}
}