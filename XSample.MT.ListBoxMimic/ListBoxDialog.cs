
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace ListBoxConcept
{
	public partial class ListBoxDialog : DialogViewController
	{
		public ListBoxDialog () : base (UITableViewStyle.Plain, null)
		{
			Section section = new Section("");
			PopulateTable(section);

			Root = new RootElement ("ListBoxDialog") 
			{
				//Section "section" with StringElementHW
				section

			};


			TableView.SeparatorColor = UIColor.White;
			TableView.AllowsSelection = true;
			TableView.UserInteractionEnabled = true;

//			TableView.SelectRow (se1.IndexPath, true, UITableViewScrollPosition.None);
//			TableView.ScrollToRow (se1.IndexPath, UITableViewScrollPosition.None, true);

		}

		/// <summary>
		/// Populates the table, for testing purposes only!
		/// </summary>
		private void PopulateTable(Section section)
		{
			int i = 0;

			for(i=0; i<10; ++i)
			{
				StringElementHW se = new StringElementHW("Q"+i.ToString());
				section.Add(se);
				se.Tapped += () => 
				{
					System.Diagnostics.Debug.WriteLine("Row Selected");
				};

			}

		}
	}
}
