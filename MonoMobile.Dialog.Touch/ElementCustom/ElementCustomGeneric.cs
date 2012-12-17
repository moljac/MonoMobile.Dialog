using System;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;


namespace MonoMobile.Dialog
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="UITableViewCellType"></typeparam>
	/// <typeparam name="BusinessObjectType"></typeparam>
	/// <see cref="http://tirania.org/monomac/archive/2011/Jan-18.html"/>
	/// <see cref="http://www.alexyork.net/blog/2011/07/18/creating-custom-uitableviewcells-with-monotouch-the-correct-way/"/>
	/// <see cref="http://simon.nureality.ca/?p=91"/>
	public partial class 
		ElementCustomGeneric<UITableViewCellType, BusinessObjectType> 
		:
		ElementCustom
		where 
			UITableViewCellType 
			: 
			// UIView OK but need more strict
			// MonoTouch.UIKit.UITableViewCell
			// event stricter - use our custom cell which has Update Function
			MonoMobile.Dialog.UITableViewCellCustomGeneric<BusinessObjectType>
			// TODO: investigate if UIView could be instead of UITableViewCell
	{

		# region    Constructors
		//-------------------------------------------------------------------------
		public ElementCustomGeneric()
			: base(null)
		{				
			return;
		}
		//-------------------------------------------------------------------------
		public ElementCustomGeneric(string filename_xib)
			: base(null)
		{
			this.FileNameXIB = filename_xib;
			
			return;
		}
		//-------------------------------------------------------------------------
		public ElementCustomGeneric(string filename_xib, string cell_identifier)
			: this(filename_xib)
		{
			this.CellReuseIdentifier = cell_identifier;
			
			return;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

		//-------------------------------------------------------------------------
		# region Property UITableViewCellCustomGeneric<BusinessObjectType> CellCustom w Event post (CellCustomChanged)
		/// <summary>
		/// CellCustom
		/// </summary>
		public
		  UITableViewCellCustomGeneric<BusinessObjectType>
		  CellCustom
		{
			get
			{
				return cell_custom;
			} // CellCustom.get
			set
			{
				//if (cell_custom != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(cell_custom) // MultiThread safe				
					{
						cell_custom = value;
						if (null != CellCustomChanged)
						{
							CellCustomChanged(this, new EventArgs());
						}
					}
				}
			} // CellCustom.set
		} // CellCustom

		/// <summary>
		/// private member field for holding CellCustom data
		/// </summary>
		private
			UITableViewCellCustomGeneric<BusinessObjectType>
			cell_custom
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// CellCustomChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			CellCustomChanged
			;
		# endregion Property UITableViewCellCustomGeneric<BusinessObjectType> CellCustom w Event post (CellCustomChanged)
		//-------------------------------------------------------------------------

		public override UITableViewCell GetCell (UITableView tv)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			
			// Reuse a cell if one exists
			// 
			// <string key="IBUIReuseIdentifier">UITableViewCellCustomGeneric</string>
			// 
			NSString memory_identifier = new NSString(CellReuseIdentifier);
			cell_custom = tv.DequeueReusableCell(memory_identifier) as UITableViewCellType;

			if (CellCustom == null) 
			{   
				if ("" == FileNameXIB || null == FileNameXIB) 
				{
					CellCustom = this.CellFromXib (FileNameXIB, tv)
										as UITableViewCellType;
				} 
				else 
				{			
					CellCustom = this.CellFromXib (FileNameXIB, tv)
										as UITableViewCellType;
				}
			}

			// This cell has been used before, so we need to update it's data
			CellCustom.DataBind(business_object);
			
			return CellCustom;
		}



	}
}

