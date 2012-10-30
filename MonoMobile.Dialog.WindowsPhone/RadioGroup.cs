using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class RadioGroup 
		: 
		Group
	{
		# region    Properites
		//-------------------------------------------------------------------------
		// int selected;
		// public virtual int Selected
		// {
		// 	get { return selected; }
		// 	set { selected = value; }
		// }
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public RadioGroup(string key)
			: base(key)
		{
			Key = key;
		}
		//-------------------------------------------------------------------------
		public RadioGroup(string key, int selected)
			: base(key)
		{
			this.Selected = selected;
			Key = key;
		}
		//-------------------------------------------------------------------------
		public RadioGroup(int selected)
			: base(null)
		{
			this.Selected = selected;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors
	}
}