using System;
using System.Collections;
using System.Collections.Generic;

using System.Windows.Media.Imaging;

using System.Windows;
using System.Windows.Controls;

namespace MonoMobile.Dialog
{
	public partial class ImageElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public Image Value
		{
			get { return image; }
			set
			{
				image = value;
				if (image_control_view_widget != null)
				{
					image_control_view_widget.
							// SetImageBitmap(image) MA
							Source = new BitmapImage()
							;
				}
			}
		}
		Image image;
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public ImageElement(Image image)
			: base("")
		{
			image = image;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

		Image image_control_view_widget;

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
			FrameworkElement fe = new Image();

			return fe;
		}
	}
}