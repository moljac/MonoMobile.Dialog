using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace ListBoxConcept
{
	public class StringElementHW : MonoTouch.Dialog.StringElement
	{
		//http://monotouch.2284126.n4.nabble.com/How-to-keep-selected-element-row-highlighted-td4655163.html
		public StringElementHW (string caption, string value) : base (caption, value)
		{
			this.Value = value;
		}
		
		public StringElementHW (string caption, NSAction tapped) : base (caption,tapped)
		{
			this.Tapped += tapped;
		}
		
		public StringElementHW (string caption) : base (caption)
		{
		}

		//INFO:
		//http://monotouch.2284126.n4.nabble.com/How-to-keep-selected-element-row-highlighted-td4655163.html
		public override void Selected (DialogViewController dvc, UITableView tableView, NSIndexPath indexPath)
		{
			// dostuff
			//tableView.DeselectRow (indexPath, true);
			tableView.SelectRow(indexPath,true,UITableViewScrollPosition.None);
		}
	}

}

