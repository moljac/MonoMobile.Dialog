using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Uri = Android.Net.Uri;

namespace MonoMobile.Dialog
{
	[Activity]
	public partial class HtmlActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			
			Intent i = this.Intent;
			string url = i.GetStringExtra("URL");
			this.Title = i.GetStringExtra("Title");
			
			WebView webview = new WebView(this);
			webview.Settings.JavaScriptEnabled = true;
			SetContentView(webview);	
			webview.LoadUrl(url);
		}
	}
}