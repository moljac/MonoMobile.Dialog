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
	public enum ElementLayout : int
	{
		dialog_boolfieldleft,		// 0 
		dialog_boolfieldright,		// 1
		dialog_boolfieldsubleft,	// 2
		dialog_boolfieldsubright,	// 3
		dialog_button,				// 4
		dialog_datefield,			// 5
		dialog_fieldsetlabel,		// 6
		dialog_labelfieldbelow,		// 7
		dialog_labelfieldright,		// 8
		dialog_onofffieldright,		// 9
		dialog_panel,				// 10
		dialog_root,				// 11
		dialog_selectlist,			// 12
		dialog_selectlistfield,		// 13
		dialog_textarea,			// 14
		dialog_floatimage,			// 15
		dialog_textfieldbelow,		// 16
		dialog_textfieldright,		// 17
	}

}