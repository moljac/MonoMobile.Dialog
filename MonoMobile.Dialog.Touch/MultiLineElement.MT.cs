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
	public partial class MultilineElement : StringElement, IElementSizing
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
		}
		//-------------------------------------------------------------------------
		public MultilineElement(string caption, NSAction tapped)
			: base(caption, tapped)
		{
		}
		//-------------------------------------------------------------------------
		# endregion Constructors



		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = base.GetCell(tv);
			var tl = cell.TextLabel;
			tl.LineBreakMode = UILineBreakMode.WordWrap;
			tl.Lines = 0;

			return cell;
		}

		public virtual float GetHeight(UITableView tableView, NSIndexPath indexPath)
		{
			float margin = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone ? 40f : 110f;
			SizeF size = new SizeF(tableView.Bounds.Width - margin, float.MaxValue);
			UIFont font = UIFont.BoldSystemFontOfSize(17);
			string c = Caption;
			// ensure the (single-line) Value will be rendered inside the cell
			if (String.IsNullOrEmpty(c) && !String.IsNullOrEmpty(Value))
				c = " ";
			return tableView.StringSize(c, font, size, UILineBreakMode.WordWrap).Height + 10;
		}
	}
}