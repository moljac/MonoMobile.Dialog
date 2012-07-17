using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MonoMobile.Dialog;

namespace DialogSampleApp
{
	public partial class UserInterface
	{
		public static RootElement UICities ()
		{
			RootElement re =
				// sample from  MA.D
				//DialogSampleApp.UserInterface.UIDefine()
				// sample from  MT.D
				//DialogSampleApp.UserInterface.UI()
				new RootElement ("Cities")
				{
				  //new AdElement()
				  new Section ("Zagreb section") 
					{
					  //new AdElement()
					 new EntryElement ("Zagreb","City", "Zagreb")
					, new DateElement ("Date", DateTime.Now)
					, new StringElement ("String", "Value", DoSomething)
					, new TimeElement("Time", DateTime.Now)
					// TODO: mc++
					// MT.D ambigious in VS only!
					// Error	1	
					// The call is ambiguous between the following methods or properties: 
					// 'MonoMobile.Dialog.Section.Add(MonoMobile.Dialog.Element)' 
					// and 
					// 'MonoMobile.Dialog.Section.Add(IEnumerable<MonoMobile.Dialog.Element>)'
					// XSample.MonoTouch
					, new RootElement("Zagreb details")
						{
					 		new Section ("Zagreb section") 
					 		{
							  new EntryElement ("Zagreb","City", "Zagreb")
					  		, new DateElement ("Date", DateTime.Now)
					 		, new StringElement ("String", "Value")
					  		, new TimeElement("Time", DateTime.Now)
							, new RootElement("Zagreb details")
								{
									new Section ("Zagreb section") 
					 				{
									  new EntryElement ("Zagreb","City", "Zagreb")
					  				, new DateElement ("Date", DateTime.Now)
					 				, new StringElement ("String", "Value")
					  				, new TimeElement("Time", DateTime.Now)
									}
								}
							} 
						}
					 }
				};
			return re;
		}


		static Section region;

		public static void DoSomething()
		{
			region.Add(new StringElement("Insertion not animated"));
		}


		public static RootElement UIDefine()
		{
			RootElement root = new RootElement("Test Root Elem")
				{
					new Section("Test Header", "Test Footer")
						{
							new StringElement("Do Something", "Foo"
								, () => {
									Console.WriteLine("Did Something");
									}
								),
							//new ButtonElement("DialogActivity", () => StartNew()),
							new BooleanElement("Push my button", true),
							new BooleanElement("Push this too", false),
							new StringElement("Text label", "The Value"),
							new BooleanElement("Push my button", true),
							new BooleanElement("Push this too", false),
						},
					new Section("Part II")
						{
							new StringElement("This is the String Element", "The Value"),
							new CheckboxElement("Check this out", true),
							new EntryElement("Username","username", "username"){
								Hint = "Enter Login"
							},
							new EntryElement("Password", "password", "", true) {
								Hint = "Enter Password",
								Password = true,
							},
						}
				};

			return root;
		}




		public static RootElement UI()
		{
			var Last = new DateTime(2010, 10, 7);
			Console.WriteLine(Last);

			var p = System.IO.Path.GetFullPath("background.png");

			RootElement menu = new RootElement("Demos")
			{
				// new Section ("Element API"){
				// 	new StringElement ("iPhone Settings Sample", DemoElementApi),
				// 	new StringElement ("Dynamically load data", DemoDynamic),
				// 	new StringElement ("Add/Remove demo", DemoAddRemove),
				// 	new StringElement ("Assorted cells", DemoDate),
				// 	new StyledStringElement ("Styled Elements", DemoStyled) { BackgroundUri = new Uri ("file://" + p) },
				// 	new StringElement ("Load More Sample", DemoLoadMore),
				// 	new StringElement ("Row Editing Support", DemoEditing),
				// 	new StringElement ("Advanced Editing Support", DemoAdvancedEditing),
				// 	new StringElement ("Owner Drawn Element", DemoOwnerDrawnElement),
				// },
				// new Section ("Container features"){
				// 	new StringElement ("Pull to Refresh", DemoRefresh),
				// 	new StringElement ("Headers and Footers", DemoHeadersFooters),
				// 	new StringElement ("Root Style", DemoContainerStyle),
				// 	new StringElement ("Index sample", DemoIndex),
				// },
				// new Section ("Json") {
				// 	(Element) (sampleJson = JsonElement.FromFile ("sample.json")),
				// 	// Notice what happens when I close the paranthesis at the end, in the next line:
				// 	(Element) new JsonElement ("Load from URL", "file://" + Path.GetFullPath ("sample.json"))
				// },
				// new Section ("Auto-mapped", footer){
				// 	new StringElement ("Reflection API", DemoReflectionApi)
				// },
			};

			//
			// Lookup elements by ID:
			//
			//JsonElement sampleJson = null;
			//var jsonSection = sampleJson["section-1"] as Section;
			//Console.WriteLine("The section has {0} elements", jsonSection.Count);
			//var booleanElement = sampleJson["first-boolean"] as BooleanElement;
			//Console.WriteLine("The state of the first-boolean value is {0}", booleanElement.Value);

			return menu;
		}

	}
}