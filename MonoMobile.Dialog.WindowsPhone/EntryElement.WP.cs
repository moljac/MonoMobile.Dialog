using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public partial class EntryElement
	{
		private void ExecutePlatformCode()
		{

		}

		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		/// Miguel's MT.D does not have constructor with 2 args, to make it conform
		/// with Kevin's MA.D I have added this 
		public EntryElement(string caption, string value)
			: base(caption)
		{
			this.Value = value;
			ExecutePlatformCode();
		}

		//-------------------------------------------------------------------------
		/// <summary>
		/// Constructs an EntryElement with the given caption, placeholder and initial value.
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
			: base(caption)
		{
			Value = value;
			Hint = placeholder_hint;				// MA.D Hint
			this.placeholder = placeholder_hint;	// MT.D placeholder
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Constructs an EntryElement for password entry with the given caption, placeholder and initial value.
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
			: base(caption)
		{
			Value = value;
			this.isPassword = isPassword;
			this.placeholder = placeholder;
			this.Password = isPassword;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

		TextBox entry;

		/// <summary>
		/// MT.D: public override UITableViewCell GetCell(UITableView tv)
		/// MA.D: public override View GetView(Context context, View convertView, ViewGroup parent)
		/// WP.D: Brainstorming needed!
		/// 
		/// Control					NOGO
		/// FrameworkElement		GO!
		/// TODO: see more!
		/// </summary>
		/// <returns></returns>
		public override FrameworkElement GetControl()
		{
			FrameworkElement fe = new TextBox();

			return fe;
		}
	}
}