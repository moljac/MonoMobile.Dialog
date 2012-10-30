using System;
using System.Windows;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public abstract partial class Element
		: 
		StackPanel
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
		public virtual FrameworkElement GetControl()
		{
			FrameworkElement fe = new StackPanel();

			return fe;
		}
	
	}
}