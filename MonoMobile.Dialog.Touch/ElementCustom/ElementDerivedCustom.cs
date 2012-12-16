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
		ElementDerivedCustom<UITableViewCellType, BusinessObjectType> 
		:
		// MonoTouch.Dialog.Element
		MonoMobile.Dialog.Element
		where 
			UITableViewCellType 
			: 
			// UIView OK but need more strict
			// MonoTouch.UIKit.UITableViewCell
			// event stricter - use our custom cell which has Update Function
			MonoMobile.Dialog.UITableViewCellCustom<BusinessObjectType>
			// TODO: investigate if UIView could be instead of UITableViewCell
	{

		# region    Constructors
		//-------------------------------------------------------------------------
		public ElementDerivedCustom()
			: base(null)
		{
			// if not given assign class-wide (static) properties to object
			this.FileNameXIB =
			ElementDerivedCustom<UITableViewCellType, BusinessObjectType>.DefaultFileNameXIB;
			this.CellReuseIdentifier =
				ElementDerivedCustom<UITableViewCellType, BusinessObjectType>.DefaultCellReuseIdentifier;
				
			return;
		}
		//-------------------------------------------------------------------------
		public ElementDerivedCustom(string filename_xib)
			: base(null)
		{
			this.FileNameXIB = filename_xib;
			
			return;
		}
		//-------------------------------------------------------------------------
		public ElementDerivedCustom(string filename_xib, string cell_identifier)
			: this(filename_xib)
		{
			this.CellReuseIdentifier = cell_identifier;
			
			return;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors


		//-------------------------------------------------------------------------
		# region Property string FileNameXIB w Event post (FileNameXIBChanged)
		/// <summary>
		/// FileNameXIB
		/// </summary>
		public
				string
				FileNameXIB
		{
			get
			{
				return file_name_xib;
			} // FileNameXIB.get
			set
			{
				//if (file_name_xib != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(file_name_xib) // MultiThread safe				
					{
						file_name_xib = value;
						if (null != FileNameXIBChanged)
						{
							FileNameXIBChanged(null, new EventArgs());
						}
					}
				}
			} // FileNameXIB.set
		} // FileNameXIB
		
		/// <summary>
		/// private member field for holding FileNameXIB data
		/// </summary>
		private
				string
				file_name_xib
				;
		
		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// FileNameXIBChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
				event
				EventHandler
				FileNameXIBChanged
				;
		# endregion Property string FileNameXIB w Event post (FileNameXIBChanged)
		//-------------------------------------------------------------------------

		private static string defaultFileNameXIB;
		public static string DefaultFileNameXIB {
			get {
				return defaultFileNameXIB;
			}
			set {
				defaultFileNameXIB = value;
			}
		}
		//-------------------------------------------------------------------------
		# region Property UITableViewCellCustom<BusinessObjectType> CellCustom w Event post (CellCustomChanged)
		/// <summary>
		/// CellCustom
		/// </summary>
		public
		  UITableViewCellCustom<BusinessObjectType>
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
			UITableViewCellCustom<BusinessObjectType>
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
		# endregion Property UITableViewCellCustom<BusinessObjectType> CellCustom w Event post (CellCustomChanged)
		//-------------------------------------------------------------------------


		//-------------------------------------------------------------------------
		# region Property string CellReuseIdentifier w Event post (CellReuseIdentifierChanged)
		/// <summary>
		/// CellReuseIdentifier
		/// </summary>
		public
				string
				CellReuseIdentifier
		{
			get
			{
				return cell_reuse_identifier;
			} // CellReuseIdentifier.get
			set
			{
				//if (cell_reuse_identifier != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(cell_reuse_identifier) // MultiThread safe				
					{
						cell_reuse_identifier = value;
						if (null != CellReuseIdentifierChanged)
						{
							CellReuseIdentifierChanged(null, new EventArgs());
						}
					}
				}
			} // CellReuseIdentifier.set
		} // CellReuseIdentifier
		
		/// <summary>
		/// private member field for holding CellReuseIdentifier data
		/// </summary>
		private
				string
				cell_reuse_identifier
				;
		
		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// CellReuseIdentifierChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
				event
				EventHandler
				CellReuseIdentifierChanged
				;
		# endregion Property string CellReuseIdentifier w Event post (CellReuseIdentifierChanged)
		//-------------------------------------------------------------------------
		
		private static string defaultCellReuseIdentifier;
		public static string DefaultCellReuseIdentifier {
			get {
				return defaultCellReuseIdentifier;
			}
			set {
				defaultCellReuseIdentifier = value;
			}
		}
		public override UITableViewCell GetCell (UITableView tv)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
			
			// Reuse a cell if one exists
			// 
			// <string key="IBUIReuseIdentifier">UITableViewCellCustom</string>
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
			CellCustom.DataBind(business_object_type);
			
			return CellCustom;
		}


		public UITableViewCell CellFromXib(string file_name_xib, UITableView tv)
		{
			// allocate/load a cell from XIB
			NSArray views = NSBundle.MainBundle.LoadNib(file_name_xib, tv, null);
			UITableViewCell cc;
			cc = Runtime.GetNSObject(views.ValueAt(0)) as UITableViewCell;

			return cc;
		}

	}
}

