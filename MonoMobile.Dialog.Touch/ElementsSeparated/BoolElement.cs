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
	public abstract class BoolElement : Element
	{
		bool val;
		public virtual bool Value
		{
			get
			{
				return val;
			}
			set
			{
				bool emit = val != value;
				val = value;
				if (emit && ValueChanged != null)
					ValueChanged(this, EventArgs.Empty);
			}
		}
		public event EventHandler ValueChanged;

		public BoolElement(string caption, bool value)
			: base(caption)
		{
			val = value;
		}

		public override string Summary()
		{
			return val ? "On".GetText() : "Off".GetText();
		}
	}

}