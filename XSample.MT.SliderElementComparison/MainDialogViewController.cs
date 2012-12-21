
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
//using MonoTouch.Dialog;
using MonoMobile.Dialog;

namespace XSample.MT.SliderElementComparison
{
	public partial class MainDialogViewController : DialogViewController
	{
	
		// TODO: moljac it would be great to implement MM.D <=> MT.D converions
		// 
		FloatElement float_element_original;
		FloatElement float_element_original_w_caption;
		FloatElement float_element_modified_01;
		FloatElement float_element_modified_02;
		
		public MainDialogViewController () : base (UITableViewStyle.Grouped, null)
		{
			float_element_original = new FloatElement(null, null, 0.8f);
			float_element_original_w_caption = new FloatElement(null, null, 0.8f)
			{
				Caption = "Desc"
			,	ShowCaption = true
			};
			float_element_modified_01 = new FloatElement("Modified 01")
			{
			};
			float_element_modified_02 = new FloatElement(0.2f, 0.9f, 0.5f)
			{
			};
			
			Root = new MonoMobile.Dialog.RootElement ("MainDialogViewController") {
				new MonoMobile.Dialog.Section ("First Section")
				{
				  float_element_original
				, float_element_original_w_caption
				, float_element_modified_01
				, float_element_modified_02
				}
			};
		}
	}
}
