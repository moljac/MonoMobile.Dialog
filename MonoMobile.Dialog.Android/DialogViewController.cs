using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MonoMobile.Dialog
{
	public partial class DialogViewController
	{

		# region ---- Property RootElement ScreenPageRootElementCurrent --------------------
		private RootElement _ScreenPageRootElementCurrent;

		public RootElement ScreenPageRootElementCurrent
		{
			get { return _ScreenPageRootElementCurrent; }
			set
			{
				if (value != _ScreenPageRootElementCurrent)
				{
					// lock(_ScreenPageRootElementCurrent) // MultiThread safe
					{
						_ScreenPageRootElementCurrent = value;
						if (null != ScreenPageRootElementCurrentChanged)
							ScreenPageRootElementCurrentChanged(this, new EventArgs());
					}
				}
			}
		}

		public event EventHandler ScreenPageRootElementCurrentChanged;
		# endregion ---- RootElement Property.ScreenPageRootElementCurrent --------------------

		private Stack<RootElement> stack_of_views_controls;

		//# region ---- Property RootElement RootElement --------------------
		//private RootElement _ScreenPage;
		//
		//public RootElement RootElement
		//{
		//	get { return RootElement; }
		//	set
		//	{
		//		if (value != RootElement)
		//		{
		//			// lock(RootElement) // MultiThread safe
		//			{
		//				RootElement = value;
		//				if (null != RootElementChanged)
		//					RootElementChanged(this, new EventArgs());
		//			}
		//		}
		//	}
		//}
		//
		//public event EventHandler RootElementChanged;
		//# endregion ---- RootElement Property.RootElement --------------------

		public DialogViewController()
		{
			return;
		}

	}
}