using System;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace MonoMobile.Dialog
{
	public partial class ElementCustomGeneric<BusinessLogicType, PresentationType> 
		: 
		//MonoTouch.Dialog.Element
		MonoMobile.Dialog.Element
		where 
			PresentationType 
			: 
			  // UIView OK but need more strict
			  UITableViewCell
	{
		//---------------------------------------------------------------------
		// RefactorStep=01
		// new variables lower in class hierarchy
		public UIView   UIViewCustom = null;
		protected NSArray  UIViewsFromXIB = null;
		public NSObject UIViewFromXIB = null;
		//---------------------------------------------------------------------
		// RefactorStep=02
		// make ElementCustomGeneric generic BusinessLogic + Presentation
		public BusinessLogicType BusinessObject;
		// public UITableViewCell PresentationObjectCell;
		//---------------------------------------------------------------------
		// RefactorStep=03
		// make PresentationObjectCell property

		protected UITableViewCell presentation_object_cell;
		public UITableViewCell PresentationObjectCell 
		{
			get 
			{
				if (null == presentation_object_cell)
				{
					// Allocate a cell
					if( null == views_from_xib)
					{
						// Loading XIB - all its views!!
						views_from_xib = NSBundle.MainBundle.LoadNib (XIBNIBName, ParentTableView, null);

					}
					// TODO: remove XIB stuff
					presentation_object_cell = Runtime.GetNSObject (views_from_xib.ValueAt (0)) as UITableViewCell;

					// Loading from object
					UITableViewCellCustomListXIBless ccx = new UITableViewCellCustomListXIBless();
					presentation_object_cell = ccx;
				}

				return presentation_object_cell;
			}
			set 
			{
				presentation_object_cell = value;
			}
		}

		NSArray 			views_from_xib;
		public string 		XIBNIBName = "CustomListCell";
		public UITableView	ParentTableView;
		UITableViewCellCustomAlternative cell;
		//---------------------------------------------------------------------

		public ElementCustomGeneric () : base (null)
		{
		}


		public delegate void UpdateDataDelegate(UITableViewCell cell);
		public event UpdateDataDelegate UpdateData;

		public override UITableViewCell GetCell (UITableView tv)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute

			ParentTableView = tv;
			// Reuse a cell if one exists
			cell = ParentTableView.DequeueReusableCell("UITableViewCellCustomAlternative")
					as UITableViewCellCustomAlternative;
			PresentationObjectCell = ParentTableView.DequeueReusableCell("UITableViewCellCustomAlternative");

			if (null == PresentationObjectCell)
			{
				// Allocate a cell
				NSArray views = NSBundle.MainBundle.LoadNib (XIBNIBName, ParentTableView, null);
				// TODO: remove XIB stuff
				PresentationObjectCell = Runtime.GetNSObject (views.ValueAt (0)) as UITableViewCell;
			}

//			if (cell == null) 
//			{   
//				cell = this.PresentationObjectCell as CustomListCell;
//
//				// Allocate a cell
//				// NSArray views = NSBundle.MainBundle.LoadNib ("CustomListCell", tableView, null);
//				// cell = Runtime.GetNSObject (views.ValueAt (0)) as CustomListCell;
//			}

			// this.SomeDelegateForMapping += ////
			//(this.PresentationObjectCell as CustomListCell).UpdateWithData();

			//			UIViewFromXIB = cell;    // OK NSObject from Runtime.GetNSObject is UIView!
//			if (PresentationObjectCell == null) 
//			{
//				PresentationObjectCell = this.PresentationObjectCell;
//			}
			// PresentationObjectCell = cell;   // OK


			// This cell has been used before, so we need to update it's data
			//cell.UpdateWithData (_testData [indexPath.Row]);   
			
			return 
				// cell					// OK too strongly typed
				PresentationObjectCell	// UITableViewCell
				;
		}
	}
}

