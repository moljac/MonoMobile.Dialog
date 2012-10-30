using System;
using Android.Content;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.App;
using System.Text;

namespace MonoMobile.Dialog
{
	/// <summary>
	/// TODO: 
	/// </summary>
	public partial class EntryElement : Element, ITextWatcher
	{
		# region    Constructors
		//-------------------------------------------------------------------------
		/// Miguel's MT.D does not have constructor with 2 args, to make it conform
		/// with Kevin's MA.D I have added this 
		public EntryElement(string caption, string value)
			: base(caption, (int)ElementLayout.dialog_textfieldright)
		{
			this.Value = value;
			ExecutePlatformCode();
		}
		//-------------------------------------------------------------------------
		protected EntryElement(string caption, string @value, int layoutId)
			: base(caption, layoutId)
		{
			value_entry_text = @value;
			Lines = 1;
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Constructs an EntryElement with the given caption, placeholder and initial
		/// value.
		/// </summary>
		/// <param name="caption">
		/// The caption to use
		/// </param>
		/// <param name="placeholder">
		/// Placeholder to display when no value is set.
		/// </param>
		/// <param name="value">
		/// Initial value.
		/// </param>
		public EntryElement(string caption, string placeholder_hint, string value)
			: base(caption, (int)ElementLayout.dialog_textfieldright)
		{
			Value = value;
			Hint = placeholder_hint;				// MA.D Hint
			this.placeholder = placeholder_hint;	// MT.D placeholder
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Constructs an EntryElement for password entry with the given caption, 
		/// placeholder and initial value.
		/// </summary>
		/// <param name="caption">
		/// The caption to use.
		/// </param>
		/// <param name="placeholder">
		/// Placeholder to display when no value is set.
		/// </param>
		/// <param name="value">
		/// Initial value.
		/// </param>
		/// <param name="isPassword">
		/// True if this should be used to enter a password.
		/// </param>
		public EntryElement(string caption, string placeholder, string value, bool isPassword)
			: base(caption, (int)ElementLayout.dialog_textfieldright)
		{
			Value = value;
			this.isPassword = isPassword;
			this.placeholder = placeholder;
			this.Password = isPassword;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors




		// mc++ commonizated!	public string Value
		// mc++ commonizated!	{
		// mc++ commonizated!		get { return value_entry_text; }
		// mc++ commonizated!		set
		// mc++ commonizated!		{
		// mc++ commonizated!			value_entry_text = value;
		// mc++ commonizated!			if (entry != null && entry.Text != value)
		// mc++ commonizated!			{
		// mc++ commonizated!				entry.Text = value;
		// mc++ commonizated!				if (ValueChanged != null)
		// mc++ commonizated!					ValueChanged(this, EventArgs.Empty);
		// mc++ commonizated!			}
		// mc++ commonizated!		}
		// mc++ commonizated!	}
		// mc++ commonizated!	
		// mc++ commonizated!	public event EventHandler ValueChanged;

		// mc++ commonizated!	private string value_entry_text;


		private void ExecutePlatformCode()
		{
			LayoutId = (int)ElementLayout.dialog_textfieldright;
		}
		
		// mc++ commonizated	public bool Password { get; set; }
		// mc++ commonizated	public string Hint { get; set; }
		public bool Numeric { get; set; }
		public int Lines { get; set; }

		// mc++ commonizated! protected EditText entry;
		protected EditText entry;
		protected Action entryClicked { get;set; }
		

		public override View GetView(Context context, View convertView, ViewGroup parent)
		{
			Log.Debug("MDD", "EntryElement: GetView: ConvertView: " + ((convertView == null) ? "false" : "true") +
				" Value: " + Value + " Hint: " + Hint + " Password: " + (Password ? "true" : "false"));
			
			
			TextView label;
			var view = DroidResources.LoadStringEntryLayout(context, convertView, parent, LayoutId, out label, out entry);
			if (view != null)
			{
				// Warning! Crazy ass hack ahead!
				// since we can't know when out convertedView was was swapped from inside us, we store the
				// old textwatcher in the tag element so it can be removed!!!! (barf, rech, yucky!)
				if (entry.Tag != null)
					entry.RemoveTextChangedListener((ITextWatcher)entry.Tag);

				entry.Text = this.Value;
				entry.Hint = this.Hint;

				if (this.Password)
					entry.InputType = (InputTypes.ClassText | InputTypes.TextVariationPassword);
				else if (this.Numeric)
					entry.InputType = (InputTypes.ClassNumber | InputTypes.NumberFlagDecimal | InputTypes.NumberFlagSigned);
				else
					entry.InputType = InputTypes.ClassText;

				// continuation of crazy ass hack, stash away the listener value so we can look it up later
				entry.Tag = this;
				entry.AddTextChangedListener(this);

				label.Text = (label != null) ? Caption: string.Empty;
			}
			return view;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				//entry.Dispose();
				entry = null;
			}
		}

		public override bool Matches(string text)
		{
			return (Value != null ? Value.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) != -1 : false) || base.Matches(text);
		}

		public void OnTextChanged(Java.Lang.ICharSequence s, int start, int before, int count)
		{
			this.Value = s.ToString();
		}

		public void AfterTextChanged(IEditable s)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Element=");
			sb.Append(this.Caption);
			sb.Append("-AfterTextChanged");
			Console.Write(sb.ToString());
			Log.Debug("MMD(mc++)", sb.ToString());

			// nothing needed

			return;
		}

		public void BeforeTextChanged(Java.Lang.ICharSequence s, int start, int count, int after)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Element=");
			sb.Append(this.Caption);
			sb.Append("-BeforeTextChanged");
			Console.Write(sb.ToString());
			Log.Debug("MMD(mc++)", sb.ToString());

			// nothing needed

			return;
		}
		
		public override void Selected ()
		{
			base.Selected ();
			
			if(entry != null) {
				var context = this.GetContext();
				var entryDialog = new AlertDialog.Builder(context)
					.SetTitle("Enter Text")
					.SetView(entry)
					.SetPositiveButton("OK", (o, e) => {
							this.Value = entry.Text;
					})
					.Create();
				
				entryDialog.Show();
			}
		}
	}
}