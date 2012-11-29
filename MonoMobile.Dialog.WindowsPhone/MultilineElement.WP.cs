using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public partial class MultilineElement 
		: 
		  StringElement		// MT.D
		// EntryElement		// MA.D
		, IElementSizing	// MT.D needed? TODO:!!
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public MultilineElement(string caption)
			: base(caption)
		{
		}
		//-------------------------------------------------------------------------
		public MultilineElement(string caption, string value)
			: base(caption, value)
		{
			// TextBlock MultiLine!!
		}
		//-------------------------------------------------------------------------
		public MultilineElement(string caption, System.Action tapped)
			: base(caption, "")
		{
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

		public virtual float GetHeight()
		{
			return float.Epsilon;
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
			StackPanel sp_multiline_element = new StackPanel()
			{
			  Orientation = System.Windows.Controls.Orientation.Vertical
			, Name = "MultilineElement"
			};

			TextBlock tb_caption = new TextBlock()
			{
				Text = this.Caption
			};
			TextBlock tb_value = new TextBlock()
			{
			  Text = this.Value
			};

			sp_multiline_element.Children.Add(tb_caption);
			sp_multiline_element.Children.Add(tb_value);

			return sp_multiline_element;
		}
	}
}