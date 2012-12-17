using System;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;


namespace MonoMobile.Dialog
{
	public partial class 
		ElementCustomGeneric<UITableViewCellType, BusinessObjectType> 
	{
		//-------------------------------------------------------------------------
		# region Property BusinessObjectType BusinessObject w Event post (BusinessObjectChanged)
		/// <summary>
		/// BusinessObject
		/// The business_object_type.
		///  BO logic type = Tag in WindowsFoms or similar! "Kinda databinding"
		/// </summary>
		public
		  BusinessObjectType
		  BusinessObject
		{
			get
			{
				return business_object;
			} // BusinessObject.get
			set
			{
				//if (business_object != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(business_object) // MultiThread safe				
					{
						business_object = value;
						if (null != BusinessObjectChanged)
						{
							BusinessObjectChanged(this, new EventArgs());
						}
					}
				}
			} // BusinessObject.set
		} // BusinessObject

		/// <summary>
		/// private member field for holding BusinessObject data
		/// </summary>
		private
			BusinessObjectType
			business_object
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// BusinessObjectChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			BusinessObjectChanged
			;
		# endregion Property BusinessObjectType BusinessObject w Event post (BusinessObjectChanged)
		//-------------------------------------------------------------------------

	}
}

