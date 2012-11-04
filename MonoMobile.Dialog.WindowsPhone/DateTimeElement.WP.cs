using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace MonoMobile.Dialog
{
	public partial class DateTimeElement
		: StringElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Constructors

		/// <summary>
		/// MA.D
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public virtual string Format(DateTime dt)
		{
			return
				dt.ToShortDateString() + " " + dt.ToShortTimeString()
				//FormatDate(dt)		// Call Miguel's Format!!
				;
		}

		/// <summary>
		/// MA.D
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public virtual string FormatDate(DateTime dt)
		{
			return
				
				Format(dt)		// Call Kevin's Format!!
				;
		}


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
			StackPanel sp_datetime_element = new StackPanel()
			{
			  Orientation = System.Windows.Controls.Orientation.Horizontal
			, Name = "DateElement"
			};

			TextBlock tb = new TextBlock()
			{
				Text = sp_datetime_element.Name
			};

			DatePicker dp = new DatePicker()
			{
			   Value = DateTime.Now
			};

			sp_datetime_element.Children.Add(tb);
			sp_datetime_element.Children.Add(dp);

			return sp_datetime_element;
		}
	}
}