using System;

using System.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Runtime;


namespace MonoMobile.Dialog
{
	public partial class StringElement : Element
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
				if (_text != null) _text.Text = _value;
			}
		}
		private string _value;
		//-------------------------------------------------------------------------
		public int FontSize { get; set; }
		//-------------------------------------------------------------------------
		public object Alignment { get; set; }
		//-------------------------------------------------------------------------
		# endregion Properites

		public StringElement(string caption)
			: base(caption, (int)ElementLayout.dialog_labelfieldright)
		{
		}

		protected StringElement(string caption, int layoutId)
			: base(caption, layoutId)
		{
		}

		public StringElement(string caption, string value)
			: base(caption, (int)ElementLayout.dialog_labelfieldright)
		{
			Value = value;
		}
		
		/// <summary>
		/// MA.D only mc++: Warning for compatibility!
		/// </summary>
		/// <param name="caption"></param>
		/// <param name="value"></param>
		/// <param name="clicked"></param>

		[Obsolete("Compatibility warning: Not available in MonoTouch.Dialog", true)]
		public StringElement(string caption, string value, Action clicked)
			: base(caption, (int)ElementLayout.dialog_labelfieldright)
		{
			Value = value;
			this.Click = clicked;
		}

		protected StringElement(string caption, string value, int layoutId)
			: base(caption, layoutId)
		{
			Value = value;
		}
		
		public StringElement(string caption, Action clicked)
			: base(caption, (int)ElementLayout.dialog_labelfieldright)
		{
			Value = null;
			this.Click = clicked;
		}

		public override View GetView(Context context, View convertView, ViewGroup parent)
		{
			View view = DroidResources.LoadStringElementLayout(context, convertView, parent, LayoutId, out _caption, out _text);
			if (view != null)
			{
				_caption.Text = Caption;
				_caption.TextSize = FontSize;
				_text.Text = Value;
				_text.TextSize = FontSize;
				if (Click != null)
					view.Click += delegate { this.Click(); };
			}
			return view;
		}
		
		public override void Selected ()
		{
			base.Selected ();
			
			if(this.Click != null) {
				Click();
			}
		}


		protected TextView _caption;
		protected TextView _text;

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				//_caption.Dispose();
				_caption = null;
				//_text.Dispose();
				_text = null;
			}
		}
	}
}