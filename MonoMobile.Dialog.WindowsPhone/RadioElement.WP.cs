using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public partial class RadioElement
		: StringElement
	{
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
			StackPanel sp_radio_element = new StackPanel()
			{
			  Orientation = System.Windows.Controls.Orientation.Vertical
			, Name = "MultilineElement"
			};

			TextBlock tb_caption = new TextBlock()
			{
				Text = this.Caption
			};
			RadioButton rb_value = new RadioButton()
			{
			};

			sp_radio_element.Children.Add(tb_caption);
			sp_radio_element.Children.Add(rb_value);

			return sp_radio_element;
		}
	}
}