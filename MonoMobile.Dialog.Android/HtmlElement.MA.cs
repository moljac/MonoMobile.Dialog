using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using System;

using Android.Webkit;
using Uri = Android.Net.Uri;

namespace MonoMobile.Dialog
{
	public partial class HtmlElement : StringElement
	{
		# region    Properites
		//-------------------------------------------------------------------------
		public string Url { get; set; }
		//-------------------------------------------------------------------------
		public Android.Net.Uri Uri { get; set; }
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		public HtmlElement(string caption, string uri)
			: base(caption)
		{
			this.Uri = Android.Net.Uri.Parse(uri);
			this.Url = uri;
		}
		//-------------------------------------------------------------------------
		[Obsolete("Not cross platform")]
		public HtmlElement(string caption, Android.Net.Uri uri)
			: base(caption)
		{
			this.Uri = uri;
			this.Url = uri.ToString();
		}
		//-------------------------------------------------------------------------
		# endregion Constructors

		// public string Value;
		

				
		void OpenUrl(Context context)
		{
			Intent intent = new Intent(context, typeof(HtmlActivity));
			intent.PutExtra("URL",this.Url.ToString());
			intent.PutExtra("Title",Caption);
			intent.AddFlags(ActivityFlags.NewTask);	
			context.StartActivity(intent);
		}

		public override View GetView(Context context, View convertView, ViewGroup parent)
		{
			View view = base.GetView (context, convertView, parent);
			
//            this.Click = (o, e) => OpenUrl(context);
			this.Click = delegate { OpenUrl(context); };

			return view;
		}
	}
}