using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MonoMobile.Dialog;
using System.Diagnostics;

namespace MonoMobile.XSample
{
	public partial class UserInterface
	{
		public static RootElement TestElements()
		{
			RootElement re1 = new RootElement("re1");
			Debug.WriteLine(re1.ToString());
			Section s1 = new Section();
			Debug.WriteLine(s1.ToString());
			//Section s2 = new Section(new Android.Views.View(a1));
			//Debug.WriteLine(s2.ToString());
			Section s3 = new Section("s3");
			Debug.WriteLine(s3.ToString());
			//Section s4 = new Section
			//					(
			//					  new Android.Views.View(a1)
			//					, new Android.Views.View(a1)
			//					);
			//Debug.WriteLine(s4.ToString());
			Section s5 = new Section("caption", "footer");
			Debug.WriteLine(s5.ToString());

			StringElement se1 = new StringElement("se1");
			Debug.WriteLine(se1.ToString());
			StringElement se2 = new StringElement("se2", delegate() { });
			Debug.WriteLine(se2.ToString());
			//StringElement se3 = new StringElement("se3", 4);
			StringElement se4 = new StringElement("se4", "v4");
			Debug.WriteLine(se4.ToString());
			//StringElement se5 = new StringElement("se5", "v5", delegate() { });
			
			// removed - protected (all with LayoutID)
			// StringElement se6 = new StringElement("se6", "v6", 4);
			// Debug.WriteLine(se6.ToString());

			// not cross platform! 
			// TODO: make it!?!?!?
			// AchievementElement
			
			BooleanElement be1 = new BooleanElement("be1", true);
			Debug.WriteLine(be1.ToString());
			BooleanElement be2 = new BooleanElement("be2", false, "key");
			Debug.WriteLine(be2.ToString());
			
			// Abstract
			// BoolElement be3 = new BoolElement("be3", true);

			CheckboxElement cb1 = new CheckboxElement("cb1");
			Debug.WriteLine(cb1.ToString());
			CheckboxElement cb2 = new CheckboxElement("cb2", true);
			Debug.WriteLine(cb2.ToString());
			CheckboxElement cb3 = new CheckboxElement("cb3", false, "group1");
			Debug.WriteLine(cb3.ToString());
			CheckboxElement cb4 = new CheckboxElement("cb4", false, "subcaption", "group2");
			Debug.WriteLine(cb4.ToString());

			DateElement de1 = new DateElement("dt1", DateTime.Now);
			Debug.WriteLine(de1.ToString());

			// TODO: see issues 
			// https://github.com/kevinmcmahon/MonoDroid.Dialog/issues?page=1&state=open
			EntryElement ee1 = new EntryElement("ee1", "ee1");
			Debug.WriteLine(ee1.ToString());
			EntryElement ee2 = new EntryElement("ee2", "ee2 placeholder", "ee2 value");
			Debug.WriteLine(ee2.ToString());
			EntryElement ee3 = new EntryElement("ee3", "ee3 placeholder", "ee3 value", true);
			Debug.WriteLine(ee3.ToString());

			FloatElement fe1 = new FloatElement("fe1");
			Debug.WriteLine(fe1.ToString());
			FloatElement fe2 = new FloatElement(-0.1f, 0.1f, 3.2f);
			Debug.WriteLine(fe2.ToString());
			FloatElement fe3 = new FloatElement
									(
									  null
									, null // no ctors new Android.Graphics.Bitmap()
									, 1.0f
									);
			Debug.WriteLine(fe3.ToString());

			HtmlElement he1 = new HtmlElement("he1", "http://holisiticware.net");
			Debug.WriteLine(he1.ToString());

			
			// TODO: image as filename - cross-platform
			ImageElement ie1 = new ImageElement(null);
			Debug.WriteLine(ie1.ToString());

			// TODO: not in Kevin's MA.D
			// ImageStringElement

			MultilineElement me1 = new MultilineElement("me1");
			Debug.WriteLine(me1.ToString());
			MultilineElement me2 = new MultilineElement("me2", delegate() { });
			Debug.WriteLine(me2.ToString());
			MultilineElement me3 = new MultilineElement("me3", "me3 value");
			Debug.WriteLine(me3.ToString());

			RadioElement rde1 = new RadioElement("rde1");
			Debug.WriteLine(rde1.ToString());
			RadioElement rde2 = new RadioElement("rde1", "group3");
			Debug.WriteLine(rde2.ToString());

			// TODO: not in Kevin's MA.D
			// StyledMultilineElement

			TimeElement te1 = new TimeElement("TimeElement", DateTime.Now);
			Debug.WriteLine(te1.ToString());



			re1.Add(s1);
			//re1.Add(s2);
			re1.Add(s3);
			//re1.Add(s4);
			re1.Add(s5);

			return re1;
		}

		public static RootElement UICities ()
		{
			RootElement re3 =
				new RootElement("Zagreb details details details re3")
								{
									new Section ("Zagreb section") 
					 				{
									  new EntryElement ("Zagreb","City", "Zagreb")
					  				, new DateElement ("Date", DateTime.Now)
					 				, new StringElement ("String", "Value")
					  				, new TimeElement("Time", DateTime.Now)
									}
								};


			re3.ElementTraversingDelegate += new Element.ElementTraversingDelegatePrototype(re3_ElementTraversingDelegate);
			re3.Traverse(re3);

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
					, new StringElement ("String", DoSomething)
					, new TimeElement("Time", DateTime.Now)
					// TODO: mc++
					// MT.D ambigious in VS only!
					// Error	1	
					// The call is ambiguous between the following methods or properties: 
					// 'MonoMobile.Dialog.Section.Add(MonoMobile.Dialog.Element)' 
					// and 
					// 'MonoMobile.Dialog.Section.Add(IEnumerable<MonoMobile.Dialog.Element>)'
					// XSample.MonoTouch
					, (Element) new RootElement("Zagreb details re1")
						{
					 		new Section ("Zagreb section") 
					 		{
							  new EntryElement ("Zagreb","City", "Zagreb")
					  		, new DateElement ("Date", DateTime.Now)
					 		, new StringElement ("String", "Value")
					  		, new TimeElement("Time", DateTime.Now)
							, (Element) new RootElement("Zagreb details details re2")
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

		static void re3_ElementTraversingDelegate(Element e)
		{
			Debug.WriteLine(e.ToString());

			return;
		}



		public static void DoSomething()
		{
			Section region;
			region =  new Section("New region/Section added in DoSomething)", "Footer");
			region.Add(new StringElement("Insertion not animated"));
		}


		public static RootElement UIDefine()
		{
			RootElement root = new RootElement("Test Root Elem")
				{
					new Section("Test Header", "Test Footer")
						{
							new StringElement("Do Something"
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