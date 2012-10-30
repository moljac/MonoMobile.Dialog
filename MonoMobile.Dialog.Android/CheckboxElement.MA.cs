using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace MonoMobile.Dialog
{
	// mc++ val renamed to val

	public partial class CheckboxElement 
		: 
		Element			//  StringElement in MT.D
		, CompoundButton.IOnCheckedChangeListener
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public bool Value
		{
			get { return val; }
			set
			{
				bool emit = val != value;
				val = value;
				if (_checkbox != null && _checkbox.Checked != val)
					_checkbox.Checked = val;
				else if (emit && ValueChanged != null)
					ValueChanged(this, EventArgs.Empty);
			}
		}
		private bool val;
		//-------------------------------------------------------------------------
		// mc++ commonized public string Group;
		//-------------------------------------------------------------------------
		# endregion Properites

		
		public string SubCaption
		{
			get
			{
				return subCap;
			}
			set
			{
				subCap = value;
			}
		}
		private string subCap;
		
		public bool ReadOnly
		{
			get;
			set;
		}
		
		public event EventHandler ValueChanged;

		private CheckBox _checkbox;
		private TextView _caption;
		private TextView _subCaption;

		// mc++ commonized public string Group;

		public CheckboxElement(string caption)
			: base(caption, (int)ElementLayout.dialog_boolfieldright)
		{
			Value = false;
		}

		public CheckboxElement(string caption, bool value)
			: base(caption, (int)ElementLayout.dialog_boolfieldright)
		{
			Value = value;
		}
		
		public CheckboxElement(string caption, bool value, string subCaption, string group)
			: base(caption, (int)ElementLayout.dialog_boolfieldsubright)
		{
			Value = value;
			Group = group;
			SubCaption = subCaption;
		}

		public CheckboxElement(string caption, bool value, string group)
			: base(caption, (int)ElementLayout.dialog_boolfieldright)
		{
			Value = value;
			Group = group;
		}

		protected CheckboxElement(string caption, bool value, string group, int layoutId)
			: base(caption, layoutId)
		{
			Value = value;
			Group = group;
		}
		
		public override View GetView(Context context, View convertView, ViewGroup parent)
		{
			View checkboxView;
			View view = DroidResources.LoadBooleanElementLayout(context, convertView, parent, LayoutId, out _caption, out _subCaption, out checkboxView);
			if (view != null)
			{
				_caption.Text = Caption;
				
				_checkbox = checkboxView as CheckBox;
				_checkbox.SetOnCheckedChangeListener(null);
				_checkbox.Checked = Value;
				_checkbox.Clickable = !ReadOnly;	
				
				if (_subCaption != null )
				{
					_subCaption.Text = SubCaption;
				}
			}
			return view;
		}

		public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
		{
			this.Value = isChecked;
		}
	}
}