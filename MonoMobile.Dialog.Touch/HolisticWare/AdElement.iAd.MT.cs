using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MonoMobile.Dialog;
using MonoTouch.iAd;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace DialogSampleApp
{
	/// <summary>
	/// http://stackoverflow.com/questions/5504077/setting-bounds-for-a-uiviewelement-monotouch-dialog
	/// </summary>
	public partial class AdElement 
	 :
	  // UIViewElement
	  //, IElementSizing
	  //Element cannot RootElement expects Section
	  Section
	{
		ADBannerView adbanner = null;
		protected UIView View;
		NSString key;
		static int count;

		public CellFlags Flags;
		
		public enum CellFlags {
			Transparent = 1,
			DisableSelection = 2
		}

				public AdElement()
			: 
			//base("AdBanner", null, false)  //UIViewElement
			base("AdBanner") // Element
		{
			key = new NSString ("AdBanner" + count++);

			
									RectangleF rect = new RectangleF(0,0,300,50);
			adbanner = new ADBannerView(rect);
			adbanner.CurrentContentSizeIdentifier = "ADBannerContentSizePortrait";
			adbanner.AdLoaded += new EventHandler(AdLoaded);
			adbanner.FailedToReceiveAd += new EventHandler<AdErrorEventArgs>(FailedToReceiveAd);
			
			
			// do no resize iAd
			//adbanner.Frame.Width = 100;

			//base.View = adbanner;
			this.View = adbanner;
			
			return;
		}


		private void AdLoaded(object sender, EventArgs e)
		{
			adbanner.Hidden = false;

			return;
		}

		private void FailedToReceiveAd(object sender, AdErrorEventArgs e)
		{
			adbanner.Hidden = true;

			return;
		}

		protected override NSString CellKey {
			get {
				return key;
			}
		}
		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = tv.DequeueReusableCell (CellKey);
			if (cell == null){
				cell = new UITableViewCell (UITableViewCellStyle.Default, CellKey);
				if ((Flags & CellFlags.Transparent) != 0){
					cell.BackgroundColor = UIColor.Clear;
					
					// 
					// This trick is necessary to keep the background clear, otherwise
					// it gets painted as black
					//
					cell.BackgroundView = new UIView (RectangleF.Empty) { 
						BackgroundColor = UIColor.Clear 
					};
				}
				if ((Flags & CellFlags.DisableSelection) != 0)
					cell.SelectionStyle = UITableViewCellSelectionStyle.None;

				if (Caption != null)
					cell.TextLabel.Text = Caption;
				cell.ContentView.AddSubview (View);
			} 
			return cell;
		}
		
		public float GetHeight (UITableView tableView, NSIndexPath indexPath)
		{
			return View.Bounds.Height;
		}
		
		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
			if (disposing){
				if (View != null){
					View.Dispose ();
					View = null;
				}
			}
		}

	}
}
