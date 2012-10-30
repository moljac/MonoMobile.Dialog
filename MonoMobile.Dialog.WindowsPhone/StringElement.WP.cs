using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public partial class StringElement
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
		public StringElement(string caption) 
			: base(caption) 
		{
		}
		//-------------------------------------------------------------------------
		public StringElement(string caption, string value)
			: base(caption)
		{
			this.Value = value;
		}
		//-------------------------------------------------------------------------
		public StringElement(string caption, Action tapped)
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
			FrameworkElement fe = new TextBlock();

			return fe;
		}
	
	}
}