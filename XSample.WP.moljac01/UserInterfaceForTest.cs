using System;
using MonoMobile.Dialog.PlatformSpecific;

namespace MonoMobile.Dialog
{
	public class UserInterfaceForTest
	{
		public static RootElement RootElelementToTest()
		{
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

					, new HtmlElement
							(
							  "HtmlElement caption"
							, new Uri("http://holisiticware.net")
							)
					, new HtmlElement
							(
							  "HtmlElement caption"
							// Miguel's samples use following!
							// TODO: see non-intrusive/non-invasive way to allow both Uri and NSURl
							, new NSUrl("http://holisiticware.net")  
							)
					}
				//, new Section("Section 02", "Footer")
				//	{
				//	}
				};


			return re;
		}
	}
}
