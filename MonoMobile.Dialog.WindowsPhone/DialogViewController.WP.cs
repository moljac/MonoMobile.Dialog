using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;

namespace MonoMobile.Dialog
{
	/// <summary>
	/// DialogViewController is StackPanel.
	/// Avoid making it Scrollviewer cause ScrollViewer is
	/// hard to maintain when stacked one into another.
	/// Therefore leave the final 'scrooling' decision
	/// to the final developer;
	/// </summary>
	public partial class DialogViewController
		:
		// UITableViewController	// MT.D
		// 
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
			this.Root = re;

			this.Loaded += new RoutedEventHandler(DialogViewController_Loaded);

			return;
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



		void DialogViewController_Loaded(object sender, RoutedEventArgs e)
		{
			this.Orientation = System.Windows.Controls.Orientation.Vertical;

			if (null != this.Root)
			{
				StackPanel sp_root = this.Root.GetControl() as StackPanel;
				try
				{
					this.Children.Add(sp_root);
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message);
				}
			}

			return;

		}

	}

}