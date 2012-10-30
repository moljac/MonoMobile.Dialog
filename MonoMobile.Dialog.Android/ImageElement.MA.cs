using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;

namespace MonoMobile.Dialog
{
	public partial class ImageElement : Element
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public Bitmap Value
		{
			get { return image; }
			set
			{
				image = value;
				if (image_control_view_widget != null)
				{
					image_control_view_widget.SetImageBitmap(image);
				}
			}
		}
		Bitmap image;
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public ImageElement(Bitmap bmp)
			: base("")
		{
			image = bmp;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

		// Height for rows
		const int dimx = 48;
		const int dimy = 44;
		
		// radius for rounding
		const int roundPx = 12;


		ImageView image_control_view_widget;

				
		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
				image.Dispose();
			}
			base.Dispose (disposing);
		}

		public override View GetView(Context context, View convertView, ViewGroup parent)
		{
			this.Click = delegate { SelectImage(); };

			Bitmap scaledBitmap = Bitmap.CreateScaledBitmap(image, dimx, dimy, true);

			var view = convertView as RelativeLayout;
			if (view == null)
			{
				view = new RelativeLayout(context);
				image_control_view_widget = new ImageView(context);
			}
			else
			{
				image_control_view_widget = (ImageView)view.GetChildAt(0);
			}
			image_control_view_widget.SetImageBitmap(scaledBitmap);
			
			var parms = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
			parms.SetMargins(5, 2, 5, 2);
			parms.AddRule( LayoutRules.AlignParentLeft);
			if(image_control_view_widget.Parent != null && image_control_view_widget.Parent is ViewGroup)
				((ViewGroup)image_control_view_widget.Parent).RemoveView(image_control_view_widget);
			view.AddView(image_control_view_widget, parms);

			return view;
		}

		private void SelectImage()
		{
			Context context = GetContext();
			Activity activity = (Activity)context;
			Intent intent = new Intent(Intent.ActionPick, global::Android.Provider.MediaStore.Images.Media.InternalContentUri);
			activity.StartActivityForResult(intent,1);
		}
	}
}