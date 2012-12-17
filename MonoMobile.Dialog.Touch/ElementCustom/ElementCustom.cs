using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace MonoMobile.Dialog
{
	public partial class ElementCustom
		:
		// MonoTouch.Dialog.Element
		MonoMobile.Dialog.Element
	{

		# region    Constructors
		//-------------------------------------------------------------------------
		public ElementCustom()
			: base(null)
		{
			// if not given assign class-wide (static) properties to object
			this.FileNameXIB = ElementCustom.DefaultFileNameXIB;
			this.CellReuseIdentifier = ElementCustom.DefaultCellReuseIdentifier;
				
			return;
		}
		//-------------------------------------------------------------------------
		public ElementCustom(string filename_xib)
			: base(null)
		{
			this.FileNameXIB = filename_xib;
			
			return;
		}
		//-------------------------------------------------------------------------
		public ElementCustom(string filename_xib, string cell_identifier)
			: this(filename_xib)
		{
			this.CellReuseIdentifier = cell_identifier;
			
			return;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

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

		//-------------------------------------------------------------------------
		# region Property string DefaultCellReuseIdentifier w Event post (DefaultCellReuseIdentifierChanged)
		/// <summary>
		/// DefaultCellReuseIdentifier
		/// </summary>
		public
			static
			string
			DefaultCellReuseIdentifier
		{
			get
			{
				return default_cell_reuse_identifier;
			} // DefaultCellReuseIdentifier.get
			set
			{
				//if (default_cell_reuse_identifier != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(default_cell_reuse_identifier) // MultiThread safe				
					{
						default_cell_reuse_identifier = value;
						if (null != DefaultCellReuseIdentifierChanged)
						{
							DefaultCellReuseIdentifierChanged(null, new EventArgs());
						}
					}
				}
			} // DefaultCellReuseIdentifier.set
		} // DefaultCellReuseIdentifier

		/// <summary>
		/// private member field for holding DefaultCellReuseIdentifier data
		/// </summary>
		private
			static
			string
			default_cell_reuse_identifier
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// DefaultCellReuseIdentifierChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			static
			event
			EventHandler
			DefaultCellReuseIdentifierChanged
			;
		# endregion Property string DefaultCellReuseIdentifier w Event post (DefaultCellReuseIdentifierChanged)
		//-------------------------------------------------------------------------

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

		//-------------------------------------------------------------------------
		# region Property string DefaultFileNameXIB w Event post (DefaultFileNameXIBChanged)
		/// <summary>
		/// DefaultFileNameXIB
		/// </summary>
		public
			static
			string
			DefaultFileNameXIB
		{
			get
			{
				return default_filename_xib;
			} // DefaultFileNameXIB.get
			set
			{
				//if (default_filename_xib != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(default_filename_xib) // MultiThread safe				
					{
						default_filename_xib = value;
						if (null != DefaultFileNameXIBChanged)
						{
							DefaultFileNameXIBChanged(null, new EventArgs());
						}
					}
				}
			} // DefaultFileNameXIB.set
		} // DefaultFileNameXIB

		/// <summary>
		/// private member field for holding DefaultFileNameXIB data
		/// </summary>
		private
			static
			string
			default_filename_xib
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// DefaultFileNameXIBChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			static
			event
			EventHandler
			DefaultFileNameXIBChanged
			;
		# endregion Property string DefaultFileNameXIB w Event post (DefaultFileNameXIBChanged)
		//-------------------------------------------------------------------------

		//  TODO: static cell for all class instances?
		//-------------------------------------------------------------------------
		# region Property UITableViewCell CellCustom w Event post (CellCustomChanged)
		/// <summary>
		/// CellCustom
		/// </summary>
		public
		  UITableViewCell
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
			UITableViewCell
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
		# endregion Property UITableViewCell CellCustom w Event post (CellCustomChanged)
		//-------------------------------------------------------------------------

	
		public override UITableViewCell GetCell(UITableView tv)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute

			// Reuse a cell if one exists
			// 
			// <string key="IBUIReuseIdentifier">UITableViewCellCustomGeneric</string>
			// 
			NSString memory_identifier = new NSString(CellReuseIdentifier);
			cell_custom = tv.DequeueReusableCell(memory_identifier) as UITableViewCell;

			if (null == CellCustom)
			{
				if (null != CellContentFactory)
				{
					// Create Cell with delegate
					CellCustom = CellContentFactory();
				}
				else if ("" != FileNameXIB && null != FileNameXIB)
				{
					// Create Cell from some XIB
					CellCustom = this.CellFromXib(FileNameXIB, tv)
										as UITableViewCell;
				}
			}
			else
			{
				CellCustom = CellContentFactoryDefault();
			}

			// DataBinding / Update 
			// TODO:
			// CellCustom.DataBind(business_object);

			return CellCustom;
		}


		public delegate UITableViewCell CellContentFactoryDelegate();
		public event CellContentFactoryDelegate CellContentFactory;

		# region    Cell Factories
		//-------------------------------------------------------------------------
		private UITableViewCell CellContentFactoryDefault()
		{
			UITableViewCell cc = null;

			return cc;
		}

		//-------------------------------------------------------------------------
		public UITableViewCell CellFromXib(string file_name_xib, UITableView tv)
		{
			return CellFromXib(file_name_xib, 0, tv);
		}
		//-------------------------------------------------------------------------
		public UITableViewCell CellFromXib(string file_name_xib, uint view_index, UITableView tv)
		{
			// allocate/load a cell from XIB
			NSArray views = NSBundle.MainBundle.LoadNib(file_name_xib, tv, null);

			UITableViewCell cc;
			cc = MonoTouch.ObjCRuntime.Runtime.GetNSObject(views.ValueAt(view_index))
								as UITableViewCell;

			return cc;
		}
		//-------------------------------------------------------------------------
		# endregion Cell Factories
	
	}
}
