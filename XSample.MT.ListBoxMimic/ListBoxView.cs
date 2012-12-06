
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ListBoxConcept
{
	public partial class ListBoxView : UIViewController
	{
		public ListBoxView () : base ("ListBoxView", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			this.NavigationController.NavigationBarHidden = true;

			//UIPickerView--------------------------------------------------------------

			//model for data loading
			PickerModel model = new PickerModel(this.View);

			//picker
			UIPickerView picker = new UIPickerView();
			picker.Frame = new RectangleF(0,164,768,216);

			picker.ShowSelectionIndicator = true;
			picker.Model = model;

			//--------------------------------------------------------------------------

			//Setup the toolbar
			UIToolbar toolbar = new UIToolbar();
			toolbar.Frame = new RectangleF(0,380,768,44);
			toolbar.BarStyle = UIBarStyle.Black;
			toolbar.Translucent = true;
			toolbar.SizeToFit();

			
			//Create a 'done' button for the toolbar and add it to the toolbar
			UIBarButtonItem doneButton = 
				new UIBarButtonItem
					("Done",UIBarButtonItemStyle.Done,
					 (s,e) => 
					 {
						//do something after the values is selected
//						this.txtCurrentAltitude.ResignFirstResponder();
						picker.RemoveFromSuperview();
						toolbar.RemoveFromSuperview();
					}
					);

			UIBarButtonItem loadButton = 
				new UIBarButtonItem
					("Load",UIBarButtonItemStyle.Bordered,
					 (s,e) => 
					 {
						//do something after the values is selected
					}
					);

			toolbar.SetItems(new UIBarButtonItem[]{doneButton,loadButton},true);

	

			btnLoadPicker.TouchUpInside += (object sender, EventArgs e) => 
			{
				this.View.AddSubview(picker);
				this.View.AddSubview(toolbar);
			};
			//UIPickerView--------------------------------------------------------------

			//DialogView----------------------------------------------------------------
			FPLView.BackgroundColor = new UIColor(0.89f,0.78f,0.56f,1.00f);
			ListBoxDialog lbd = new ListBoxDialog();
			MTDView.AddSubview(lbd.View);

			btnFPLLoad.BackgroundColor = new UIColor(0.78f,0.65f,0.39f,1.00f);
			//COLOR ON PRESS
//			btnFPLLoad.TintColor = new UIColor(0.78f,0.65f,0.39f,1.00f);


			btnFPLCancel.BackgroundColor = new UIColor(0.78f,0.65f,0.39f,1.00f);

			btnFPLCancel.TouchUpInside += (object sender, EventArgs e) => 
			{
				FPLView.RemoveFromSuperview();
			};
			btnDialog.TouchUpInside += (object sender, EventArgs e) => 
			{
				this.View.AddSubview(FPLView);
			};

		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return true;
		}
	}
}

