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

		public ElementCustomDerived (UITableViewCellCustom cell_custom) : base (null)
		{
			CellCustom = cell_custom;
		}

		public ElementCustomDerived (string xib_to_load) : base (null)
		{
			xib_name = xib_to_load;
		}

		private string xib_name = "";
		
		UITableViewCellCustom cellCustom;
		public UITableViewCellCustom CellCustom 
		{
			get {
				return cellCustom;
			}
			set {
				cellCustom = value;
			}
		}
		
		public override UITableViewCell GetCell (UITableView tv)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			
			// Reuse a cell if one exists
			CellCustom  = tv.DequeueReusableCell ("UITableViewCellCustom") as UITableViewCellCustom;
			
			if ( null == CellCustom) 
			{   
				//  Allocate a cell from XIB
				NSArray views = NSBundle.MainBundle.LoadNib (xib_name, tv, null);
				CellCustom = Runtime.GetNSObject (views.ValueAt (0)) as UITableViewCellCustom;
			}
			
			// This cell has been used before, so we need to update it's data
			//cell.UpdateWithData (_testData [indexPath.Row]);   
			
			return CellCustom;
		}
	}
}

