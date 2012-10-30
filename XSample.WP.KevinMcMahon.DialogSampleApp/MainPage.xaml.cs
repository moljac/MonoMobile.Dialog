using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using MonoMobile.Dialog;

using DialogSampleApp;

namespace XSample.WP.KevinMcMahon.DialogSampleApp
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


			# region    Loading StackPanel from Code
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
			# endregion Loading StackPanel from Code

			// TODO: traversing RootElement tree with DialogViewController
			// Single Inheritance - Elements cannot inherit from both 
			//		Element 
			// and 
			//		Windows Phone controls
			// Suggested API:
			//		RootElement.Children
			// during traversal children add themselves to parent?!?!
			RootElement re = RootElementFactory.CreateRootElement();

			return;
		}
	}
}