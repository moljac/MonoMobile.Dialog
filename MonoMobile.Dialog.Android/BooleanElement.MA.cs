using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace MonoMobile.Dialog
{
	/// <summary>
	/// Used to display toggle button on the screen.
	/// </summary>
	public partial class BooleanElement : BoolElement, CompoundButton.IOnCheckedChangeListener
	{
		private ToggleButton _toggleButton;
		private TextView _caption;
		private TextView _subCaption;



		# region    Constructors
		//-------------------------------------------------------------------------
		public BooleanElement(string caption, bool value)
			: base(caption, value, (int)ElementLayout.dialog_onofffieldright)
		{
		}
		//-------------------------------------------------------------------------
		protected BooleanElement(string caption, bool value, int layoutId)
			: base(caption, value, layoutId)
		{
		}
		//-------------------------------------------------------------------------
		public BooleanElement(string caption, bool value, string key)
			: base(caption, value, key, (int)ElementLayout.dialog_onofffieldright)
		{ }
		//-------------------------------------------------------------------------
		# endregion Constructors
	


		public override View GetView(Context context, View convertView, ViewGroup parent)
		{
			View toggleButtonView;
			View view = DroidResources.LoadBooleanElementLayout(context, convertView, parent, LayoutId, out _caption, out _subCaption, out toggleButtonView);

			if (view != null)
			{
				_caption.Text = Caption;
				_toggleButton = toggleButtonView as ToggleButton;
				_toggleButton.SetOnCheckedChangeListener(null);
				_toggleButton.Checked = Value;
				_toggleButton.SetOnCheckedChangeListener(this);
			}
			return view;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				//_toggleButton.Dispose();
				_toggleButton = null;
				//_caption.Dispose();
				_caption = null;
			}
		}

		public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
		{
			this.Value = isChecked;
		}
	}
}