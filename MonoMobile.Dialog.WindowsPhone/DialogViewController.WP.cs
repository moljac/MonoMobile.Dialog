using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public partial class DialogViewController
		: 
		// UITableViewController	// MT.D
		StackPanel
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		private Button buttonBack = null;

		# region    Constructors
		//-------------------------------------------------------------------------
		public DialogViewController(RootElement re)
		{
			this.root = re;
			// Is
			// re.Parent = this;
			this.Children.Add(re);
		}
		//-------------------------------------------------------------------------
		public DialogViewController(RootElement root, bool pushing)
		{
			if (true == pushing)
			{
				buttonBack = new Button();
				buttonBack.Content = "<- Back";
				this.Children.Add(buttonBack);
			}

			return;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors
	}
}