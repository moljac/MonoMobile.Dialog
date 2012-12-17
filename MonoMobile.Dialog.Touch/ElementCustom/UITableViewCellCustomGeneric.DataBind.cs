using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using MonoTouch.UIKit;

namespace MonoMobile.Dialog
{
	public delegate void DataBindDelegate<BusinessObjectType>
			(
			  UITableViewCellCustomGeneric<BusinessObjectType> cell
			, BusinessObjectType bot
			);

	public partial class UITableViewCellCustomGeneric<BusinessObjectType>
	{
		public abstract void DataBind(BusinessObjectType bot);

		public event DataBindDelegate<BusinessObjectType> DataBindMethod;

	}
}
