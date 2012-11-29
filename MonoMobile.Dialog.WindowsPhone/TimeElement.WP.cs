using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace MonoMobile.Dialog
{
	public partial class TimeElement
		: DateTimeElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public TimeElement(string caption, DateTime date)
			: base(caption, date)
		{
		}
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
			StackPanel sp_time_element = new StackPanel()
			{
			  Orientation = System.Windows.Controls.Orientation.Horizontal
			, Name = "DateElement"
			};

			TextBlock tb = new TextBlock()
			{
				Text = this.Caption
			};

			TimePicker tp = new TimePicker()
			{
				Value = DateTime.Now
			};

			sp_time_element.Children.Add(tb);
			sp_time_element.Children.Add(tp);

			return sp_time_element;
		}
	}
}