using System;
using MonoTouch;
using MonoTouch.UIKit;
using MonoTouch.Foundation;


using System.Collections.Generic;

namespace ListBoxConcept
{
	public class PickerModel : UIPickerViewModel
		
	{
		
		
		public event EventHandler<PickerChangedEventArgs> PickerChanged;
		
		List<string> column1 = new List<string>()
		{				
			"0 ft", "1000 ft","2000 ft", "3000 ft",	
			"4000 ft"
		};
		
		List<string> column2 = new List<string>()
		{				
			"0 ft", "500 ft","1000 ft", "1500 ft", "2000 ft", "2500 ft"
		};
		
		List<string> column3 = new List<string>()
		{				
			"0 ft", "50 ft", "100 ft", "150 ft", "200 ft", "250 ft", "300 ft", "350 ft", "400 ft"    
		};
		
		List<List<string>> columns = new List<List<string>>();
		
		
		
		//AppDelegate ad;
		
		public PickerModel(UIView currentView)
		{
			columns.Add(column1);
			columns.Add(column2);
			columns.Add(column3);
			
			
			
			
			return;
		}
		
		//			public ProtocolData(AppDelegate pad){
		//				
		//				ad = pad;
		//				
		//			}
		
		public override int GetComponentCount(UIPickerView uipv)
		{
			
			return(3);
			
		}
		
		public override int GetRowsInComponent (UIPickerView uipv, int component)
		{
			int retval1 = columns[component].Count;
			//			int retval2 = -1;
			//			
			//			if (component == 0) {
			//				retval2 = column1.Count;
			//			} else if (component == 1) {
			//				retval2 = column2.Count;
			//			} else if (component == 2) {
			//				retval2 = column3.Count;
			//			} else {
			//				throw new ArgumentOutOfRangeException("Prevec kolona!!");
			//			}
			
			return retval1;
		}
		
		public override string GetTitle(UIPickerView uipv, int row, int component)
		{
			
			//each component would get its own title.			
			return columns[component][row];
			
		}
		
		//			public override void Selected(UIPickerView uipv, int row, int comp)
		//			{
		//
		//				ad.SelectedRow = row;
		//		
		//				
		//			}
		
		public override float GetComponentWidth(UIPickerView uipv, int comp)
		{
			
			return(200f);
			
		}
		
		public override float GetRowHeight(UIPickerView uipv, int comp)
		{
			
			return(40f); 
			
		}
		
		public class PickerChangedEventArgs : EventArgs
		{
			public string SelectedValue { get; set; }
		}
		
		public override void Selected (UIPickerView picker, int row, int component)
		{
			if (this.PickerChanged != null)
			{
				this.PickerChanged(this, new PickerChangedEventArgs{SelectedValue = columns[component][row]});
			}
		}
		
		
	}
}