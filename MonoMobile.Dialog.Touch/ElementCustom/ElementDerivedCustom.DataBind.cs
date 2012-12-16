using System;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;


namespace MonoMobile.Dialog
{
	public partial class 
		ElementDerivedCustom<UITableViewCellType, BusinessObjectType> 
	{
		/// <summary>
		/// The business_object_type.
		///  BO logic type = Tag in WindowsFoms or similar! "Kinda databinding"
		/// </summary>
		BusinessObjectType business_object_type;
		public BusinessObjectType BusinessObject
		{
			get {
				return business_object_type;
			}
			set {
				business_object_type = value;
			}
		}
	}
}

