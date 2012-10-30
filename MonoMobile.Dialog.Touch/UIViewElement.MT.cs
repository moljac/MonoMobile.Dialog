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
	///   This element can be used to insert an arbitrary UIView
	/// </summary>
	/// <remarks>
	///   There is no cell reuse here as we have a 1:1 mapping
	///   in this case from the UIViewElement to the cell that
	///   holds our view.
	/// </remarks>
	public partial class UIViewElement : Element, IElementSizing
	{
		static int count;
		NSString key;
		protected UIView View;
		public CellFlags Flags;

		public enum CellFlags
		{
			Transparent = 1,
			DisableSelection = 2
		}

		/// <summary>
		///   Constructor
		/// </summary>
		/// <param name="caption">
		/// The caption, only used for RootElements that might want to summarize results
		/// </param>
		/// <param name="view">
		/// The view to display
		/// </param>
		/// <param name="transparent">
		/// If this is set, then the view is responsible for painting the entire area,
		/// otherwise the default cell paint code will be used.
		/// </param>
		public UIViewElement(string caption, UIView view, bool transparent)
			: base(caption)
		{
			this.View = view;
			this.Flags = transparent ? CellFlags.Transparent : 0;
			key = new NSString("UIViewElement" + count++);
		}

		protected override NSString CellKey
		{
			get
			{
				return key;
			}
		}
		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = tv.DequeueReusableCell(CellKey);
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, CellKey);
				if ((Flags & CellFlags.Transparent) != 0)
				{
					cell.BackgroundColor = UIColor.Clear;

					// 
					// This trick is necessary to keep the background clear, otherwise
					// it gets painted as black
					//
					cell.BackgroundView = new UIView(RectangleF.Empty)
					{
						BackgroundColor = UIColor.Clear
					};
				}
				if ((Flags & CellFlags.DisableSelection) != 0)
					cell.SelectionStyle = UITableViewCellSelectionStyle.None;

				if (Caption != null)
					cell.TextLabel.Text = Caption;
				cell.ContentView.AddSubview(View);
			}
			return cell;
		}

		public float GetHeight(UITableView tableView, NSIndexPath indexPath)
		{
			return View.Bounds.Height;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				if (View != null)
				{
					View.Dispose();
					View = null;
				}
			}
		}
	}
}