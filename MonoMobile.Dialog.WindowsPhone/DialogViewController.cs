using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class DialogViewController
	{
		# region    Properites
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property RootElement Root w Event post (RootChanged)
		/// <summary>
		/// Root
		/// </summary>
		public
		  RootElement
		  Root
		{
			get
			{
				return root;
			} // Root.get
			set
			{
				//if (re != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(re) // MultiThread safe				
					{
						root = value;
						if (null != RootChanged)
						{
							RootChanged(this, new EventArgs());
						}
					}
				}
			} // Root.set
		} // Root

		/// <summary>
		/// private member field for holding Root data
		/// </summary>
		private
			RootElement
			root
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// RootChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			RootChanged
			;
		# endregion Property RootElement Root w Event post (RootChanged)
		//-------------------------------------------------------------------------
	
		//-------------------------------------------------------------------------
		# endregion Properites

		# region    Constructors
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Constructors

		bool pushing;
		bool dirty;
		bool reloading;

		Section[] originalSections;
		Element[][] originalElements;
	}
}