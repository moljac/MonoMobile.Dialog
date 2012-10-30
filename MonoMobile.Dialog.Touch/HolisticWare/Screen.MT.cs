using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoMobile.Dialog;
using MonoTouch.UIKit;

namespace MonoMobile.Dialog
{
	/// <summary>
	/// </summary>
	public partial class Screen
		:
		UINavigationController
	{
		public DialogViewController dv = null;
		
		public Screen ()
		{
			dv = new DialogViewController(null);	
		}
		public void Navigate(RootElement root_element_next_screen)
		{
			// TODO: mc++
			// is new DialgoViewController necessary?
			dv = new DialogViewController 
						(
						  root_element_next_screen
						, true
						);
						
			// iOS version??!?!
			this.PushViewController (dv, true);					

			return;
		}
		
		public void Refresh ()
		{
			if (null == dv) {
				return;
			} else {
				dv.TriggerRefresh ();
			}
			
			return;
		}
	}
}
