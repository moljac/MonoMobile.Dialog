//
// Elements.cs: defines the various components of our view
//
// Author:
//   Miguel de Icaza (miguel@gnome.org)
//
// Copyright 2010, Novell, Inc.
//
// Code licensed under the MIT X11 license
//
// TODO: StyledStringElement: merge with multi-line?
// TODO: StyledStringElement: add image scaling features?
// TODO: StyledStringElement: add sizing based on image size?
// TODO: Move image rendering to StyledImageElement, reason to do this: the image loader would only be imported in this case, linked out otherwise
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;
using MonoTouch.Foundation;
using MonoMobile.Dialog.Utilities;
using MonoTouch.CoreAnimation;

namespace MonoMobile.Dialog
{
	/// <summary>
	///  Used to display a cell that will launch a web browser when selected.
	/// </summary>
	public partial class HtmlElement : Element
	{
		NSUrl nsUrl;
		static NSString hkey = new NSString("HtmlElement");
		UIWebView web;

		public HtmlElement(string caption, string url)
			: base(caption)
		{
			Url = url;
		}

		public HtmlElement(string caption, NSUrl url)
			: base(caption)
		{
			nsUrl = url;
		}

		protected override NSString CellKey
		{
			get
			{
				return hkey;
			}
		}
		public string Url
		{
			get
			{
				return nsUrl.ToString();
			}
			set
			{
				nsUrl = new NSUrl(value);
			}
		}

		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = tv.DequeueReusableCell(CellKey);
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, CellKey);
				cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;
			}
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			cell.TextLabel.Text = Caption;
			return cell;
		}

		static bool NetworkActivity
		{
			set
			{
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = value;
			}
		}

		// We use this class to dispose the web control when it is not
		// in use, as it could be a bit of a pig, and we do not want to
		// wait for the GC to kick-in.
		class WebViewController : UIViewController
		{
			HtmlElement container;

			public WebViewController(HtmlElement container)
				: base()
			{
				this.container = container;
			}

			public override void ViewWillDisappear(bool animated)
			{
				base.ViewWillDisappear(animated);
				NetworkActivity = false;
				if (container.web == null)
					return;

				container.web.StopLoading();
				container.web.Dispose();
				container.web = null;
			}

			public bool Autorotate { get; set; }

			public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
			{
				return Autorotate;
			}
		}

		public override void Selected(DialogViewController dvc, UITableView tableView, NSIndexPath path)
		{
			var vc = new WebViewController(this)
			{
				Autorotate = dvc.Autorotate
			};

			web = new UIWebView(UIScreen.MainScreen.Bounds)
			{
				BackgroundColor = UIColor.White,
				ScalesPageToFit = true,
				AutoresizingMask = UIViewAutoresizing.All
			};
			web.LoadStarted += delegate
			{
				NetworkActivity = true;
				var indicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.White);
				vc.NavigationItem.RightBarButtonItem = new UIBarButtonItem(indicator);
				indicator.StartAnimating();
			};
			web.LoadFinished += delegate
			{
				NetworkActivity = false;
				vc.NavigationItem.RightBarButtonItem = null;
			};
			web.LoadError += (webview, args) =>
			{
				NetworkActivity = false;
				vc.NavigationItem.RightBarButtonItem = null;
				if (web != null)
					web.LoadHtmlString(
						String.Format("<html><center><font size=+5 color='red'>{0}:<br>{1}</font></center></html>",
						"An error occurred:".GetText(), args.Error.LocalizedDescription), null);
			};
			vc.NavigationItem.Title = Caption;

			vc.View.AutosizesSubviews = true;
			vc.View.AddSubview(web);

			dvc.ActivateController(vc);
			web.LoadRequest(NSUrlRequest.FromUrl(nsUrl));
		}
	}
}