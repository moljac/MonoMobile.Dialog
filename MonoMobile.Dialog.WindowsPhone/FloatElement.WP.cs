using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public partial class FloatElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public FloatElement(string caption)
			: base(caption)
		{
			Value = 0;
			MinValue = 0;
			MaxValue = 10;
		}
		//-------------------------------------------------------------------------
		public FloatElement(float value, float min, float max)
			: base("")
		{
			Value = value;
			MinValue = min;
			MaxValue = max;
		}
		//-------------------------------------------------------------------------
		public FloatElement(Image left, Image right, float value)
			: base(null)
		{
			Left = left;
			Right = right;
			MinValue = 0;
			MaxValue = 1;
			Value = value;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

		static string skey = "FloatElement";
		Image Left, Right;
		Slider slider;

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
			FrameworkElement fe = new Slider();

			return fe;
		}
	}
}