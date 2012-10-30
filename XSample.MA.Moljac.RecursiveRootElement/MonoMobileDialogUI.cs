using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoMobile.Dialog;

namespace XSample.Mono4Android.Moljac.RecursiveRootElement
{
	public partial class MonoMobileDialogUI
	{
		public
			RootElement
			CreateDialogUI
			(
			)
		{
			RootElement re = 
						new RootElement("Recursive Root Element Test") 
									{
									  // MonoDialog.Android by Kevin McMahon 
									  // needs at leas one Section or Element
									  // otherwise Exception will be thrown
									  new Section("Test")
										{
										}
									};
			return re;
		}
	}
}