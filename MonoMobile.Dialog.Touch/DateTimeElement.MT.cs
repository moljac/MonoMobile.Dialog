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
	public partial class DateTimeElement : StringElement
	{
		public UIDatePicker datePicker;
		public event Action<DateTimeElement> DateSelected;

		protected internal NSDateFormatter fmt = new NSDateFormatter()
		{
			DateStyle = NSDateFormatterStyle.Short
		};

		public virtual string FormatDate(DateTime dt)
		{
			dt = GetDateWithKind(dt);
			return fmt.ToString(dt) + " " + dt.ToLocalTime().ToShortTimeString();
		}

		/// <summary>
		/// MA.D unification
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public virtual string Format(DateTime dt)
		{
			return this.FormatDate(dt);
		}

		public override UITableViewCell GetCell(UITableView tv)
		{
			Value = FormatDate(DateValue);
			var cell = base.GetCell(tv);
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				if (fmt != null)
				{
					fmt.Dispose();
					fmt = null;
				}
				if (datePicker != null)
				{
					datePicker.Dispose();
					datePicker = null;
				}
			}
		}

		protected DateTime GetDateWithKind(DateTime dt)
		{
			if (dt.Kind == DateTimeKind.Unspecified)
				return DateTime.SpecifyKind(dt, DateTimeKind.Local);

			return dt;
		}


		public virtual UIDatePicker CreatePicker()
		{
			var picker = new UIDatePicker(RectangleF.Empty)
			{
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
				Mode = UIDatePickerMode.DateAndTime,
				Date = DateValue
			};
			return picker;
		}

		static RectangleF PickerFrameWithSize(SizeF size)
		{
			var screenRect = UIScreen.MainScreen.ApplicationFrame;
			float fY = 0, fX = 0;

			switch (UIApplication.SharedApplication.StatusBarOrientation)
			{
				case UIInterfaceOrientation.LandscapeLeft:
				case UIInterfaceOrientation.LandscapeRight:
					fX = (screenRect.Height - size.Width) / 2;
					fY = (screenRect.Width - size.Height) / 2 - 17;
					break;

				case UIInterfaceOrientation.Portrait:
				case UIInterfaceOrientation.PortraitUpsideDown:
					fX = (screenRect.Width - size.Width) / 2;
					fY = (screenRect.Height - size.Height) / 2 - 25;
					break;
			}

			return new RectangleF(fX, fY, size.Width, size.Height);
		}

		class MyViewController : UIViewController
		{
			DateTimeElement container;

			public MyViewController(DateTimeElement container)
			{
				this.container = container;
			}

			public override void ViewWillDisappear(bool animated)
			{
				base.ViewWillDisappear(animated);
				container.DateValue = container.datePicker.Date;
				if (container.DateSelected != null)
					container.DateSelected(container);
			}

			public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
			{
				base.DidRotate(fromInterfaceOrientation);
				container.datePicker.Frame = PickerFrameWithSize(container.datePicker.SizeThatFits(SizeF.Empty));
			}

			public bool Autorotate { get; set; }

			public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
			{
				return Autorotate;
			}
		}

		public override void Selected(DialogViewController dvc, UITableView tableView, NSIndexPath path)
		{
			var vc = new MyViewController(this)
			{
				Autorotate = dvc.Autorotate
			};
			datePicker = CreatePicker();
			datePicker.Frame = PickerFrameWithSize(datePicker.SizeThatFits(SizeF.Empty));

			vc.View.BackgroundColor = UIColor.Black;
			vc.View.AddSubview(datePicker);
			dvc.ActivateController(vc);
		}
	}
}