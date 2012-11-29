using System;
using System.Collections;
using System.Collections.Generic;
using MonoMobile.Dialog.PlatformSpecific;

using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace MonoMobile.Dialog
{
	public partial class HtmlElement
		: Element
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public string Url { get; set; }
		//-------------------------------------------------------------------------
		public Uri Uri { get; set; }
		//-------------------------------------------------------------------------
		# endregion Properites

		NSUrl url_ns;

		# region    Constructors
		//-------------------------------------------------------------------------
		public HtmlElement(string caption, string url)
			: base(caption)
		{
			this.Url = url;
			this.Uri = new NSUrl(url);
			uri_netfx = new System.Uri(url);
		}
		//-------------------------------------------------------------------------
		public HtmlElement(string caption, NSUrl url)
			: base(caption)
		{
			url_ns = url;
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
			StackPanel sp_button_navigate = new StackPanel()
			{
			  Orientation = System.Windows.Controls.Orientation.Horizontal
			, Name = "DateElement"
			};

			TextBlock tb = new TextBlock()
			{
				Text = this.Caption
			};

			Button b = new Button()
			{
				Content = "Visit/View"
			};

			sp_button_navigate.Children.Add(tb);
			sp_button_navigate.Children.Add(b);

			return sp_button_navigate;
		}
	}
}