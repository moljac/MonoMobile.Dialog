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
	public partial class StyledMultilineElement : StyledStringElement, IElementSizing
	{
		public StyledMultilineElement(string caption) : base(caption) { }
		public StyledMultilineElement(string caption, string value) : base(caption, value) { }
		public StyledMultilineElement(string caption, NSAction tapped) : base(caption, tapped) { }
		public StyledMultilineElement(string caption, string value, UITableViewCellStyle style)
			: base(caption, value)
		{
			this.style = style;
		}

		public virtual float GetHeight(UITableView tableView, NSIndexPath indexPath)
		{
			float margin = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone ? 40f : 110f;
			SizeF maxSize = new SizeF(tableView.Bounds.Width - margin, float.MaxValue);

			if (this.Accessory != UITableViewCellAccessory.None)
				maxSize.Width -= 20;

			string c = Caption;
			string v = Value;
			// ensure the (multi-line) Value will be rendered inside the cell when no Caption is present
			if (String.IsNullOrEmpty(c) && !String.IsNullOrEmpty(v))
				c = " ";

			var captionFont = Font ?? UIFont.BoldSystemFontOfSize(17);
			float height = tableView.StringSize(c, captionFont, maxSize, LineBreakMode).Height;

			if (!String.IsNullOrEmpty(v))
			{
				var subtitleFont = SubtitleFont ?? UIFont.SystemFontOfSize(14);
				if (this.style == UITableViewCellStyle.Subtitle)
				{
					height += tableView.StringSize(v, subtitleFont, maxSize, LineBreakMode).Height;
				}
				else
				{
					float vheight = tableView.StringSize(v, subtitleFont, maxSize, LineBreakMode).Height;
					if (vheight > height)
						height = vheight;
				}
			}

			return height + 10;
		}
	}

}