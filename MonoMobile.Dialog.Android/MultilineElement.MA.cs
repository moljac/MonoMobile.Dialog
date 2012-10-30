using Android.Content;
using Android.Views;

namespace MonoMobile.Dialog
{
	public partial class MultilineElement 
		:
		EntryElement		// MA.D
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public int Lines { get; set; }
		//-------------------------------------------------------------------------
		public int MaxLength { get; set; }
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		// TODO: rewrite using this()
		//-------------------------------------------------------------------------
		public MultilineElement(string caption, string value)
			: base(caption, value, (int)ElementLayout.dialog_textarea)
		{
			Lines = 3;
		}
		//-------------------------------------------------------------------------
		public MultilineElement(string caption)
			: base(caption, "", (int)ElementLayout.dialog_textarea)
		{
		}
		//-------------------------------------------------------------------------
		public MultilineElement(string caption, System.Action tapped)
			: base(caption, "", (int)ElementLayout.dialog_textarea)
		{
		}
		//-------------------------------------------------------------------------
		# endregion Constructors


		public override View GetView(Context context, View convertView, ViewGroup parent)
		{
			View view = DroidResources.LoadMultilineElementLayout(context, convertView, parent, LayoutId, out entry);
			if (entry != null)
			{
				entry.SetLines(Lines);
				entry.Text = Value;
				entry.Hint = Caption;
				entry.TextChanged += delegate(object sender, global::Android.Text.TextChangedEventArgs e) {
					if(MaxLength > 0 && entry.Text.Length > MaxLength)
						entry.Text = entry.Text.Substring(0,MaxLength);
				};
			}
			return view;
		}

	}
}