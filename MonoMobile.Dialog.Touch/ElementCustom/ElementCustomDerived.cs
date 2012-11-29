using System;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

//using MonoTouch.Dialog;
using MonoMobile.Dialog;

namespace MonoMobile.Dialog
{
	public class ElementCustomDerived : Element
	{
		public ElementCustomDerived () : base (null)
		{
		}

		public override UITableViewCell GetCell (UITableView tableView)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			
			// Reuse a cell if one exists
			UITableViewCellCustom cell = tableView.DequeueReusableCell ("ColorCell") as UITableViewCellCustom;
			
			if (cell == null) {   
				// We have to allocate a cell
				var views = NSBundle.MainBundle.LoadNib ("UITableViewCellCustom", tableView, null);
				cell = Runtime.GetNSObject (views.ValueAt (0)) as UITableViewCellCustom;
			}
			
			// This cell has been used before, so we need to update it's data
			//cell.UpdateWithData (_testData [indexPath.Row]);   
			
			return cell;
			
		}
	}
}

