using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class RootElement 
	{
		// RootElement to mimic back like in MonoTouch
		private RootElement root_element_navigate_back;

		public RootElement(string caption, RootElement navigate_back)
			: this(caption)
		{
			//this.Add(new StringElement("Back", BackClicked));

			return;
		}

		private void BackClicked()
		{
			return;
		}
	}
}