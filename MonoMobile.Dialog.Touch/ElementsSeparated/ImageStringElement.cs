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
	public partial class ImageStringElement : StringElement
	{
		static NSString skey = new NSString("ImageStringElement");
		UIImage image;
		public UITableViewCellAccessory Accessory { get; set; }

		public ImageStringElement(string caption, UIImage image)
			: base(caption)
		{
			this.image = image;
			this.Accessory = UITableViewCellAccessory.None;
		}

		public ImageStringElement(string caption, string value, UIImage image)
			: base(caption, value)
		{
			this.image = image;
			this.Accessory = UITableViewCellAccessory.None;
		}

		public ImageStringElement(string caption, NSAction tapped, UIImage image)
			: base(caption, tapped)
		{
			this.image = image;
			this.Accessory = UITableViewCellAccessory.None;
		}

		protected override NSString CellKey
		{
			get
			{
				return skey;
			}
		}
		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = tv.DequeueReusableCell(CellKey);
			if (cell == null)
			{
				cell = new UITableViewCell(Value == null ? UITableViewCellStyle.Default : UITableViewCellStyle.Subtitle, CellKey);
				cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;
			}

			cell.Accessory = Accessory;
			cell.TextLabel.Text = Caption;
			cell.TextLabel.TextAlignment = Alignment;

			cell.ImageView.Image = image;

			// The check is needed because the cell might have been recycled.
			if (cell.DetailTextLabel != null)
				cell.DetailTextLabel.Text = Value == null ? "" : Value;

			return cell;
		}

	}
}