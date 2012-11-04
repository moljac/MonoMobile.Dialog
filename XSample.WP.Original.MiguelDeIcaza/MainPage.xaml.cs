using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
// using System.Windows.Documents; mc++ Ambigious with MM.D Section
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;


using MonoMobile.Dialog;
using Sample;


namespace XSample.WP.Original.MiguelDeIcaza
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			RootElement re =
					new AppDelegate().CreateRootHolisticWare()
					;

			DialogViewController dvc =
					new DialogViewController(re)
					// new DialogViewController(e, true)
					;

			// LayoutRoot
			ContentPanel.Children.Add(dvc);

			return;
		}
	}
}