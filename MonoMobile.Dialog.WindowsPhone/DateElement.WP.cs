using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace MonoMobile.Dialog
{
	public partial class DateElement 
		:
		DateTimeElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public DateElement(string caption, DateTime date)
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
			StackPanel sp_date_element = new StackPanel()
			{
			  Orientation = System.Windows.Controls.Orientation.Horizontal
			, Name = "DateElement"
			};

			TextBlock tb = new TextBlock()
			{
				Text = sp_date_element.Name
			};

			DatePicker dp = new DatePicker()
			{
			   Value = DateTime.Now
			};

			sp_date_element.Children.Add(tb);
			sp_date_element.Children.Add(dp);

			return sp_date_element;
		}	
	}
}