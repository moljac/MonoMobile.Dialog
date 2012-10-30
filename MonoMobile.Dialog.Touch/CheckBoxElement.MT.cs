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
	public partial class CheckboxElement : StringElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		// public new bool Value;

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
		// mc++ commonized public string Group;
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public CheckboxElement(string caption) : base(caption) { }
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
		# endregion Constructors



		UITableViewCell ConfigCell(UITableViewCell cell)
		{
			cell.Accessory = Value ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
			return cell;
		}

		public override UITableViewCell GetCell(UITableView tv)
		{
			return ConfigCell(base.GetCell(tv));
		}

		public override void Selected(DialogViewController dvc, UITableView tableView, NSIndexPath path)
		{
			Value = !Value;
			var cell = tableView.CellAt(path);
			ConfigCell(cell);
			base.Selected(dvc, tableView, path);
		}

	}

}