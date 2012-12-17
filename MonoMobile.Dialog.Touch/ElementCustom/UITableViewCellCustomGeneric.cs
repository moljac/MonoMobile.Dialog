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
	public abstract partial class UITableViewCellCustomGeneric<BusinessObjectType>
		:
		UITableViewCellCustom
	{
		# region    Constructors
		//-------------------------------------------------------------------------
		public UITableViewCellCustomGeneric()
			: base()
		{
		}
		//-------------------------------------------------------------------------
		public UITableViewCellCustomGeneric(IntPtr handle)
			: base(handle)
		{

		}
		//-------------------------------------------------------------------------
		# endregion Constructors
	
	}
}
