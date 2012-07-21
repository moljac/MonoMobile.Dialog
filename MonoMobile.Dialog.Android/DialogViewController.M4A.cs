using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MonoMobile.Dialog
{
	public partial class DialogViewController
	{
		# region ---- Property ActivityMonoMobileDialog ContextUIViewController --------------------
		private ActivityMonoMobileDialog _ContextUIViewController;

		public ActivityMonoMobileDialog ContextUIViewController
		{
			get { return _ContextUIViewController; }
			set
			{
				if (value != _ContextUIViewController)
				{
					// lock(_ContextUIViewController) // MultiThread safe
					{
						_ContextUIViewController = value;
						if (null != ContextUIViewControllerChanged)
							ContextUIViewControllerChanged(this, new EventArgs());
					}
				}
			}
		}

		public event EventHandler ContextUIViewControllerChanged;
		# endregion ---- ActivityMonoMobileDialog Property.ContextUIViewController --------------------

		public RootElement ReDraw(RootElement re)
		{
			ContextUIViewController.ReDraw(re);

			return re;
		}
	}
}