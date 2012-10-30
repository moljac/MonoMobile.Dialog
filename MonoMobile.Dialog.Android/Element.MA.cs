using System;
using Android.Content;
using Android.Views;

using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public abstract partial class Element : Java.Lang.Object, IDisposable
	{


		# region    Constructors
		//-------------------------------------------------------------------------
		protected Element(string caption, int layoutId)
		{
			Caption = caption;
			LayoutId = layoutId;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors
	

		public int LayoutId 
		{ 
			get; 
			// private
			protected set; 
		}


		/// <summary>
		/// Override for click the click event
		/// </summary>
		public Action Click { get; set; }

		/// <summary>
		/// Override for long click events, some elements use this for action
		/// </summary>
		public Action LongClick { get; set; }

		
		/// <summary>
		/// Overriden my most derived classes, creates a view that creates a View with the contents for display
		/// </summary>
		/// <param name="context"></param>
		/// <param name="convertView"></param>
		/// <param name="parent"></param>
		/// <returns></returns>
		public virtual View GetView(Context context, View convertView, ViewGroup parent)
		{
			var view = LayoutId == 0 ? new View(context) : null;
			
			
//			view.Click += delegate {
//				
//			};
//			
//			if (view != null)
//            {
//                _caption.Text = Caption;
//				_caption.TextSize = FontSize;
//                _text.Text = Value;
//				_text.TextSize = FontSize;
//				if (Click != null)
//					view.Click += this.Click; 
//            }
			return view;
		}

		public virtual void Selected() 
		{
			Console.WriteLine("foo");
		}
				

		public Context GetContext()
		{
			Element element = this;
			while (element.Parent != null)
				element = element.Parent;

			RootElement rootElement = element as RootElement;
			return rootElement == null ? null : rootElement.Context;
		}
	}
}