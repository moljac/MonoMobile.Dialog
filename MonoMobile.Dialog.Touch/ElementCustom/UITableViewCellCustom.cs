using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoMobile.Dialog
{
	/// <summary>
	/// Customized UITablViewCell based on BusinessObjectType (Business/Model/Domain Logic)
	/// The class is abstract, so the user must inherit from it  and implement methods
	/// for DataBinding.
	/// </summary>
	/// <typeparam name="BusinessObjectType"></typeparam>
	public abstract partial class UITableViewCellCustom<BusinessObjectType>
		: 
		MonoTouch.UIKit.UITableViewCell
	{

		# region    Constructors
		//-------------------------------------------------------------------------
		public UITableViewCellCustom()
			: base()
		{
		}
		//-------------------------------------------------------------------------
		public UITableViewCellCustom(IntPtr handle)
			: base(handle)
		{

		}
		//-------------------------------------------------------------------------
		# endregion Constructors
	
	}
}
