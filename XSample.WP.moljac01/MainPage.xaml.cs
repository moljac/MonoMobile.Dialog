using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
// using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;




using MonoMobile.Dialog;
using MonoMobile.Dialog.PlatformSpecific;

namespace XSample.WP.moljac01
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();


			# region    Loading Button from code
			//-------------------------------------------------------------------------
			// Button b = new Button();
			// b.Content = "Loading Button from code";
			// ContentPanel.Children.Add(b);
			//-------------------------------------------------------------------------
			# endregion Loading Button from code


			# region    Loading StackPanle from Code
			//-------------------------------------------------------------------------
			// StackPanel stackpanel = new StackPanel();
			// for (int i = 1; i <= 10; i++)
			// {
			// 	Button b = new Button();
			// 	b.Content = "Button " + i.ToString();
			// 	stackpanel.Children.Add(b);
			// }
			// ContentPanel.Children.Add(stackpanel);
			//-------------------------------------------------------------------------
			# endregion Loading StackPanle from Code


			RootElement re = UserInterfaceForTest.RootElelementToTest();

			DialogViewController dvc = 
				new DialogViewController(re)
				// new DialogViewController(e, true)
				;

			// LayoutRoot.Children.Add(dvc);
			ContentPanel.Children.Add(dvc);
		}
	}
}