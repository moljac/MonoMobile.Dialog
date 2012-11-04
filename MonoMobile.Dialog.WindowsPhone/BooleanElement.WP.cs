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
			StackPanel sp_boolean_element = new StackPanel()
			{
			  Orientation = System.Windows.Controls.Orientation.Horizontal
			, Name = "BooleanElement"
			};

			TextBlock tb = new TextBlock()
			{
			  Text = sp_boolean_element.Name
			};

			CheckBox cb = new CheckBox()
			{
			  IsChecked = this.Value
			};

			sp_boolean_element.Children.Add(tb);
			sp_boolean_element.Children.Add(cb);

			return sp_boolean_element;
		}
	}
}