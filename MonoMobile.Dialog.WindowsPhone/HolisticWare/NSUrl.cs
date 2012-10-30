using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoMobile.Dialog.PlatformSpecific
{
	/// <summary>
	/// In MT.D Miguel has used in ctors (HtmlElement) platform specific stuff
	/// 
	/// TODO: implement NSUrl in MA and WP
	/// TODO: add implicit explicit conversions to Url (MA and WP)
	/// 
	/// TODO:	see		Uri(string, string)			WP???
	///					Uri(string, UriKind)		????
	/// </summary>
	public partial class NSUrl
	{

		//-------------------------------------------------------------------------
		# region Property string OriginalString w Event post (OriginalStringChanged)
		/// <summary>
		/// OriginalString
		/// </summary>
		public
		  string
		  OriginalString
		{
			get
			{
				return original_string;
			} // OriginalString.get
			set
			{
				//if (original_string != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(original_string) // MultiThread safe				
					{
						original_string = value;
						if (null != OriginalStringChanged)
						{
							OriginalStringChanged(this, new EventArgs());
						}
					}
				}
			} // OriginalString.set
		} // OriginalString

		/// <summary>
		/// private member field for holding OriginalString data
		/// </summary>
		private
			string
			original_string
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// OriginalStringChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			OriginalStringChanged
			;
		# endregion Property string OriginalString w Event post (OriginalStringChanged)
		//-------------------------------------------------------------------------

	
		# region    Constructors
		//-------------------------------------------------------------------------
		public NSUrl()
		{
			this.original_string = null;
		}
		//-------------------------------------------------------------------------
		public NSUrl(string u)
			: this()
		{
			this.OriginalString = u;

			return;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors


		# region    Conversions
		//-------------------------------------------------------------------------
		// User defined implicit conversion
		public static implicit operator NSUrl(Uri u)
		{
			return new NSUrl(u.OriginalString);
		}
		//  User-defined conversion from double to Digit 
		public static implicit operator Uri(NSUrl u)
		{
			return new Uri(u, "");
		}
		//-------------------------------------------------------------------------
		# endregion Conversions
	
	}
}
