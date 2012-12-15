using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class UITableViewCellCustomListXIBless : UITableViewCell
	{  

		public UITableViewCellCustomListXIBless () : base()
		{
			UIView view = UIViewFactory();
			this.AddSubview(view);

			return;
		}
		
		public UITableViewCellCustomListXIBless (IntPtr handle) : base(handle)
		{
			UIView view = UIViewFactory();
			this.AddSubview(view);

			return;
		}
		
		// TODO: delegate
		public void UpdateData(string name, string timespan, bool delete)
		{			
			// make View dirty
			this.SetNeedsDisplay();

		}

		//CUSTOM CELL
		public UIView UIViewFactory()
		{
			UIView uiview_xibless = new UIView();
			uiview_xibless.Frame = new RectangleF(0,0,768,44);

			UIButton btnDelete;
			UILabel lblName;
			UILabel lblDate;

			btnDelete = UIButton.FromType(UIButtonType.Custom);
			btnDelete.Frame = new RectangleF(7,8,103,27);
	
			//UIControlState = Normal -> default system state for iOS element
			//UIControlState = Highlighted -> Highlighted state of a control. 
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

			uiview_xibless.AddSubviews(views);

			return uiview_xibless;
		}

		
		
	}
}

