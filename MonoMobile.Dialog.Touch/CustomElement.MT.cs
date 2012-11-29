
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
	///   The string element can be used to render some text in a cell 
	///   that can optionally respond to tap events.
	/// </summary>
	public partial class CustomElelement : Element
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}
		private string _value;
		//-------------------------------------------------------------------------
		# endregion Properites

		public UITextAlignment Alignment = UITextAlignment.Left;

		static NSString skey = new NSString("CustomElelement");
		static NSString skeyvalue = new NSString("CustomElelementValue");

		# region    Constructors
		//-------------------------------------------------------------------------
		public CustomElelement(string caption) : base(caption) { }
		//-------------------------------------------------------------------------
		public CustomElelement(string caption, string value)
			: base(caption)
		{
			this.Value = value;
		}
		//-------------------------------------------------------------------------
		public CustomElelement(string caption, NSAction tapped)
			: base(caption)
		{
			Tapped += tapped;
		}
		public event NSAction Tapped;
		//-------------------------------------------------------------------------
		# endregion Constructors




		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = tv.DequeueReusableCell(Value == null ? skey : skeyvalue);
			if (cell == null)
			{
				cell = new UITableViewCell(Value == null ? UITableViewCellStyle.Default : UITableViewCellStyle.Value1, skey);
				cell.SelectionStyle = (Tapped != null) ? UITableViewCellSelectionStyle.Blue : UITableViewCellSelectionStyle.None;
			}

			cell.Accessory = UITableViewCellAccessory.None;
			cell.TextLabel.Text = Caption;
			cell.TextLabel.TextAlignment = Alignment;

			// The check is needed because the cell might have been recycled.
			if (cell.DetailTextLabel != null)
				cell.DetailTextLabel.Text = Value == null ? "" : Value;

			return cell;
		}


		public override void Selected(DialogViewController dvc, UITableView tableView, NSIndexPath indexPath)
		{
			if (Tapped != null)
				Tapped();
			tableView.DeselectRow(indexPath, true);
		}

	}

}