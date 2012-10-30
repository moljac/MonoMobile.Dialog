using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	/// <summary>
	/// Used by re elements to fetch information when they need to
	/// render a summary (Checkbox count or selected radio group).
	/// </summary>
	public partial class Group
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public int Selected { get; set; }
		//-------------------------------------------------------------------------
		public string Key { get; set; }
		//-------------------------------------------------------------------------
		# endregion Properites

		public Group(string key)
		{
			Key = key;
		}

	}
}