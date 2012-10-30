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
	

	
			RootElement re = new RootElement("Caption")
			{
				new Section ("Section") 
				{
					new EntryElement ("caption", "placeholder", ""),
					new RootElement ("Root 2") {
						new Section ("Section") {
							new EntryElement ("caption", "placeholder", ""),
							new StringElement ("Back", () => {}
								)
						}
					}
				}
			};
			DialogViewController dcv = new DialogViewController(re);

			ContentPanel.Children.Add(dcv);




		}
	}
}