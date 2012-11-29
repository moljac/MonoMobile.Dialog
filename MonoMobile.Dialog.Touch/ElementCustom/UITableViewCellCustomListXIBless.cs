using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class UITableViewCellCustomListXIBless : UITableViewCell
	{  
		UIButton btnDelete;
		UILabel lblName; 
		UILabel lblDate;

		public UITableViewCellCustomListXIBless () : base()
		{
			DrawCell();
		}
		
		public UITableViewCellCustomListXIBless (IntPtr handle) : base(handle)
		{
			DrawCell();
		}
		
		// TODO: delegate
		public void UpdateData(string name, string timespan, bool delete)
		{
			lblName.Text = name;
			lblDate.Text = timespan;
			btnDelete.Hidden = false;	// (Mapping["delte"] == "true") ? true : false;
			
			// make View dirty
			this.SetNeedsDisplay();

		}

		//CUSTOM CELL
		public UIView[] DrawCell()
		{
			ContentView.Frame = new RectangleF(0,0,768,44);

			btnDelete = UIButton.FromType(UIButtonType.Custom);
			btnDelete.Frame = new RectangleF(7,8,103,27);
	
			//UIControlState = Normal -> default system state for iOS element
			//UIControlState = Highlited -> Highlighted state of a control. 
			//								A control enters this state when a touch enters and exits 
			//								during tracking and when there is a touch up event.
			btnDelete.SetTitleColor(UIColor.Blue,UIControlState.Normal);
			btnDelete.SetTitleColor(UIColor.Red,UIControlState.Highlighted);

			btnDelete.SetTitle("Delete", UIControlState.Normal);
			btnDelete.TouchUpInside += (object sender, EventArgs e) => 
			{
				
			};
			lblName = new UILabel(new RectangleF(140,11,489,21));
			lblDate = new UILabel(new RectangleF(583,11,165,21));

			lblName.Text = "Name";
			lblDate.Text = DateTime.Now.ToString();

			UIView [] views = 
			{
				btnDelete,
				lblName,
				lblDate
			};

			
			ContentView.AddSubviews(views);

			return views;
		}

		
		
	}
}

