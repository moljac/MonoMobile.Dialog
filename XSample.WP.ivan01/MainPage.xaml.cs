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

using MonoMobile.XSample;

namespace MonoMobile.XSample
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			// TODO: traversing RootElement tree with DialogViewController
			// Single Inheritance - Elements cannot inherit from both 
			//		Element 
			// and 
			//		Windows Phone controls
			// Suggested API:
			//		RootElement.Children
			// during traversal children add themselves to parent?!?!

			RootElement re = UserInterface.TestElements();

		}
	}
}