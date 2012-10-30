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
	public partial class BooleanImageElement : BaseBooleanImageElement
	{
		UIImage onImage, offImage;

		public BooleanImageElement(string caption, bool value, UIImage onImage, UIImage offImage)
			: base(caption, value)
		{
			this.onImage = onImage;
			this.offImage = offImage;
		}

		protected override UIImage GetImage()
		{
			if (Value)
				return onImage;
			else
				return offImage;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			onImage = offImage = null;
		}
	}

}