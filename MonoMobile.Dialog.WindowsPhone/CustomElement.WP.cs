using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public partial class CustomElement
		: Element
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}
		private string _value;
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public CustomElement(string caption) 
			: base(caption) 
		{
		}
		//-------------------------------------------------------------------------
		public CustomElement(string caption, string value)
			: base(caption)
		{
			this.Value = value;
		}
		//-------------------------------------------------------------------------
		public CustomElement(string caption, Action tapped)
			: base(caption)
		{
			Tapped += tapped;
		}
		public event Action Tapped;
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
			StackPanel sp_string_element = new StackPanel()
			{
			  Orientation = System.Windows.Controls.Orientation.Horizontal
			, Name = "StringElement"
			};

			TextBlock tb_caption = new TextBlock();
			tb_caption.Text = this.Caption;

			TextBlock tb_value = new TextBlock();
			tb_value.Text = this.Value;

			sp_string_element.Children.Add(tb_caption);
			sp_string_element.Children.Add(tb_value);

			return sp_string_element;
		}
	
	}
}