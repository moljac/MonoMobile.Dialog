using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public partial class CheckboxElement
		: Element
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public new bool Value
		{
			get { return val; }
			set
			{
				bool emit = val != value;
				val = value;
			}
		}
		private bool val;
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public CheckboxElement(string caption) : base(caption) { }
		//-------------------------------------------------------------------------
		public CheckboxElement(string caption, bool value)
			: base(caption)
		{
			Value = value;
		}
		//-------------------------------------------------------------------------
		public CheckboxElement(string caption, bool value, string group)
			: this(caption, value)
		{
			this.Group = group;
		}
		//-------------------------------------------------------------------------
		public CheckboxElement(string caption, bool value, string subCaption, string group)
			: this(caption, value)
		{
			Group = group;
			// TODO: SubCaption = subCaption;
		}
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