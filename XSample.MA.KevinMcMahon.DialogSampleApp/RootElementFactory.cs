using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using MonoMobile.Dialog;


namespace DialogSampleApp
{
	public partial class RootElementFactory
	{
		public static RootElement CreateRootElement()
		{
			RootElement root = new RootElement("Test Root Elem")
				{
				  new Section("Test Header", "Test Footer")
						{
						  new StringElement
										(
										  "Do Something"
										, () => 
											{
												Console.WriteLine("Did Something");						
											}
										)
						// mc++ No ButtonElement in MT.D!!!
						// mc++ TODO: add Obsolete Attribute or ButtonElelement
						// , new ButtonElement("DialogActivity", () => StartNew())
						, new BooleanElement("Push my button", true)
						, new BooleanElement("Push this too", false)
						, new StringElement("Text label", "The Value")
						, new BooleanElement("Push my button", true)
						, new BooleanElement("Push this too", false)
						,
						}
				, new Section("Part II")
						{
							new StringElement("This is the String Element", "The Value"),
							new CheckboxElement("Check this out", true),
							new EntryElement("Username",""){
								Hint = "Enter Login"
							},
							new EntryElement("Password", "") {
								Hint = "Enter Password",
								Password = true,
							},
						}
				};

			return root;
		}

	}
}