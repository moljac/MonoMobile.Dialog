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
	public partial class DialogInstanceData : Java.Lang.Object
	{
		public DialogInstanceData()
		{
			_dialogState = new Dictionary<string, string>();
		}

		private Dictionary<String, String> _dialogState;
	}
}