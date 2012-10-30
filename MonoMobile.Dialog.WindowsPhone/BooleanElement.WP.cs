using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public partial class BooleanElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public BooleanElement(string caption, bool value)
			: base(caption, value)
		{ }
		//-------------------------------------------------------------------------
		public BooleanElement(string caption, bool value, string key)
			: base(caption, value)
		{ }
		//-------------------------------------------------------------------------
		# endregion Constructors



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
			FrameworkElement fe = new CheckBox();

			return fe;
		}
	}
}