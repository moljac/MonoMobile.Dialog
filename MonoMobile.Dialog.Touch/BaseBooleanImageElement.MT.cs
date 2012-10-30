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
	///  This class is used to render a string + a state in the form
	/// of an image.  
	/// </summary>
	/// <remarks>
	/// It is abstract to avoid making this element
	/// keep two pointers for the state images, saving 8 bytes per
	/// slot.   The more derived class "BooleanImageElement" shows
	/// one way to implement this by keeping two pointers, a better
	/// implementation would return pointers to images that were 
	/// preloaded and are static.
	/// 
	/// A subclass only needs to implement the GetImage method.
	/// </remarks>
	public abstract class BaseBooleanImageElement : BoolElement
	{
		static NSString key = new NSString("BooleanImageElement");

		public partial class TextWithImageCellView : UITableViewCell
		{
			const int fontSize = 17;
			static UIFont font = UIFont.BoldSystemFontOfSize(fontSize);
			BaseBooleanImageElement parent;
			UILabel label;
			UIButton button;
			const int ImageSpace = 32;
			const int Padding = 8;

			public TextWithImageCellView(BaseBooleanImageElement parent_)
				: base(UITableViewCellStyle.Value1, parent_.CellKey)
			{
				parent = parent_;
				label = new UILabel()
				{
					TextAlignment = UITextAlignment.Left,
					Text = parent.Caption,
					Font = font,
					BackgroundColor = UIColor.Clear
				};
				button = UIButton.FromType(UIButtonType.Custom);
				button.TouchDown += delegate
				{
					parent.Value = !parent.Value;
					UpdateImage();
					if (parent.Tapped != null)
						parent.Tapped();
				};
				ContentView.Add(label);
				ContentView.Add(button);
				UpdateImage();
			}

			void UpdateImage()
			{
				button.SetImage(parent.GetImage(), UIControlState.Normal);
			}

			public override void LayoutSubviews()
			{
				base.LayoutSubviews();
				var full = ContentView.Bounds;
				var frame = full;
				frame.Height = 22;
				frame.X = Padding;
				frame.Y = (full.Height - frame.Height) / 2;
				frame.Width -= ImageSpace + Padding;
				label.Frame = frame;

				button.Frame = new RectangleF(full.Width - ImageSpace, -3, ImageSpace, 48);
			}

			public void UpdateFrom(BaseBooleanImageElement newParent)
			{
				parent = newParent;
				UpdateImage();
				label.Text = parent.Caption;
				SetNeedsDisplay();
			}
		}

		public BaseBooleanImageElement(string caption, bool value)
			: base(caption, value)
		{
		}

		public event NSAction Tapped;

		protected abstract UIImage GetImage();

		protected override NSString CellKey
		{
			get
			{
				return key;
			}
		}
		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = tv.DequeueReusableCell(CellKey) as TextWithImageCellView;
			if (cell == null)
				cell = new TextWithImageCellView(this);
			else
				cell.UpdateFrom(this);
			return cell;
		}
	}
}