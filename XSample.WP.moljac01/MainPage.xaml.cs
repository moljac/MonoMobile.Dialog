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
	
	
			RootElement re = 
				new RootElement("Caption")
				{
				  new Section ("Section 00") 
					{
					  new EntryElement ("caption", "placeholder", "")
					, new RootElement ("Root 2") 
						{
						  new Section ("Section") 
							{
							  new EntryElement ("caption", "placeholder", "")
							, new StringElement ("Back", () => {})
							}
						}
					}
				, new Section("Section 01", "Footer")
					{
					  new StringElement("StringElement caption")
					, new StringElement("StringElement caption", "value")
					, new EntryElement("EntryElement caption", "value")
					, new EntryElement("EntryElement caption", "hint", "value")
					, new EntryElement("EntryElement caption", "placeholder", "value", true)
					//, new BooleanElement("BooleanElement caption", false)

					// Exception:
					// 'UI Task' (Managed): Loaded 'System.SR.dll'
					// A first chance exception of type 'System.IO.FileNotFoundException' 
					// occurred in mscorlib.dll
					//, new BooleanElement("BooleanElement caption", false, "key")
					, new CheckboxElement("CheckboxElement caption")
					, new CheckboxElement("CheckboxElement caption", false)
					, new CheckboxElement("CheckboxElement caption", true, "group")
					, new CheckboxElement("CheckboxElement caption", true, "subcaption", "group")
					, new DateElement("DateElement caption", DateTime.Now)
					//, new DateElement("DateElement1 caption", DateTime.Now)
					//, new DateElement("DateElement2 caption", DateTime.Now)
					//, new DateElement("DateElement3 caption", DateTime.Now)
					//, new DateElement("DateElement4 caption", DateTime.Now)
					//, new DateElement("DateElement5 caption", DateTime.Now)
					, new DateTimeElement("DateTimeElement caption", DateTime.Now)
					, new DateTimeElement("DateTimeElement1 caption", DateTime.Now)
					, new FloatElement("")
					, new FloatElement(0.4f, 0.0f, 10f)
					, new ImageElement(null)
					, new MultilineElement("MultilineElement caption")
					, new MultilineElement("MultilineElement caption", delegate(){})
					, new MultilineElement("MultilineElement caption", "value")
					//, new HtmlElement("HtmlElement caption", new NSUrl("http://holisiticware.net"))
					}
				//, new Section("Section 02", "Footer")
				//	{
				//	}
				};

			DialogViewController dvc = 
				new DialogViewController(re)
				// new DialogViewController(e, true)
				;

			// LayoutRoot.Children.Add(dvc);
			ContentPanel.Children.Add(dvc);




		}
	}
}