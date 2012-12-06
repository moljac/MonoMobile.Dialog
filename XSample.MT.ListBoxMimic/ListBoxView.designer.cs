// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace ListBoxConcept
{
	[Register ("ListBoxView")]
	partial class ListBoxView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnLoadPicker { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnDialog { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView FPLView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView MTDView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnFPLLoad { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnFPLCancel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnLoadPicker != null) {
				btnLoadPicker.Dispose ();
				btnLoadPicker = null;
			}

			if (btnDialog != null) {
				btnDialog.Dispose ();
				btnDialog = null;
			}

			if (FPLView != null) {
				FPLView.Dispose ();
				FPLView = null;
			}

			if (MTDView != null) {
				MTDView.Dispose ();
				MTDView = null;
			}

			if (btnFPLLoad != null) {
				btnFPLLoad.Dispose ();
				btnFPLLoad = null;
			}

			if (btnFPLCancel != null) {
				btnFPLCancel.Dispose ();
				btnFPLCancel = null;
			}
		}
	}
}
