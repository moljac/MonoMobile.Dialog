﻿//
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
	///  Used to display a slider on the screen.
	/// </summary>
	public partial class FloatElement : Element
	{

		/// <summary>
		/// Modified MonoMobile.Dialog Cell creation when Min and Max Values are present
		/// </summary>
		/// <returns></returns>
		private UITableViewCell UITableViewCellSliderWithValueAndMinMaxFactory(UITableView tv)
		{
			UITableViewCell cell = tv.DequeueReusableCell(CellKey);
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, CellKey);
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			}
			else
				RemoveTag(cell, 1);

			SizeF captionSize = new SizeF(0, 0);

			UILabel labelMinValue = null;
			UILabel labelMaxValue = null;
			UILabel labelValue = null;

			if (MinValue != null)
			{
				labelMinValue = new UILabel();
				labelMinValue.Text = this.MinValue.ToString();
				cell.ContentView.AddSubview(labelMinValue);				
			}
			

			if (slider == null)
			{
				slider = new UISlider(new RectangleF(10f + captionSize.Width, 12f, 280f - captionSize.Width, 7f))
				{
					BackgroundColor = UIColor.Clear,
					MinValue = this.MinValue,
					MaxValue = this.MaxValue,
					Continuous = true,
					Value = this.Value,
					Tag = 1
				};
				slider.ValueChanged += delegate
				{
					Value = slider.Value;
				};
				
				//cell.ContentView.AddSubview(slider);
			}
			else
			{
				slider.Value = Value;
			}

			if (MaxValue != null)
			{
				labelMaxValue = new UILabel();
				labelMaxValue.Text = this.MaxValue.ToString();
				cell.ContentView.AddSubview(labelMaxValue);
			}
			
			if (Value != null)
			{
				RectangleF rf = new RectangleF(200,0,20,20);
				labelValue = new UILabel(rf);
				labelValue.Text = this.Value.ToString();
				cell.ContentView.AddSubview(labelValue);
			}
			
			return cell;
		}


	}
}