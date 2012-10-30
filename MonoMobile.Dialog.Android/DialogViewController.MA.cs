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

		# region    Constructors
		//-------------------------------------------------------------------------
		public DialogViewController(RootElement root)
		{
			this.root = root;
		}
		//-------------------------------------------------------------------------
		/// <summary>
		///     Creates a new DialogViewController from a RootElement and sets the push status
		/// </summary>
		/// <param name="root">
		/// The <see cref="RootElement"/> containing the information to render.
		/// </param>
		/// <param name="pushing">
		/// A <see cref="System.Boolean"/> describing whether this is being pushed 
		/// (NavigationControllers) or not.   If pushing is true, then the back button 
		/// will be shown, allowing the user to go back to the previous controller
		/// </param>
		public DialogViewController(RootElement root, bool pushing)
		{
			this.pushing = pushing;
			this.root = root;
		}
		//-------------------------------------------------------------------------
		// TODO: mc++ MA.D is this necessary??
		public DialogViewController(IntPtr handle)
		{
			this.root = new RootElement("");
		}
		//-------------------------------------------------------------------------
		// public DialogViewController(UITableViewStyle style, RootElement root, bool pushing)
		// 	: base(style)
		// {
		// 	Style = style;
		// 	this.pushing = pushing;
		// 	this.root = root;
		// }
		//-------------------------------------------------------------------------
		// public DialogViewController(UITableViewStyle style, RootElement root)
		// 	: base(style)
		// {
		// 	Style = style;
		// 	this.root = root;
		// }
		//-------------------------------------------------------------------------
		# endregion Constructors

	}
}