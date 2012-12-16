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
			  UITableViewCellCustom<BusinessObjectType> cell
			, BusinessObjectType bot
			);

	public partial class UITableViewCellCustom<BusinessObjectType>
	{
		public abstract void DataBind(BusinessObjectType bot);

		public event DataBindDelegate<BusinessObjectType> DataBindMethod;

	}
}
