using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class EntryElement
		: Element
	{
		# region    Properites
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property string Value w Event post (ValueChanged)
		/// <summary>
		/// Value
		/// </summary>
		public
		  string
		  Value
		{
			get
			{
				return value_entry_text;
			} // Value.get
			set
			{
				//if (value_entry_text != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginning with //MT:
					//MT: lock(value_entry_text) // MultiThread safe				
					{
						value_entry_text = value;

						if (null != ValueChanged)
						{
							ValueChanged(this, new EventArgs());
							// MT.D 
							// EntryElemnt.MT.cs
							Changed(this, EventArgs.Empty);
						}

						if (entry != null)
						{
							entry.Text = value_entry_text;
						}
						else
						{
							return;
						}
					}
				}
			} // Value.set
		} // Value

		/// <summary>
		/// private member field for holding Value data
		/// </summary>
		private
			string
			value_entry_text
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// ValueChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			ValueChanged
			;
		# endregion Property string Value w Event post (ValueChanged)
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		/// <summary>
		/// MT.D event needed for backward compatibility
		/// </summary>
		public event EventHandler Changed;	
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property bool Password w Event post (PasswordChanged)
		/// <summary>
		/// Password
		/// </summary>
		public
		  bool
		  Password
		{
			get
			{
				return password;
			} // Password.get
			set
			{
				//if (password != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginning with //MT:
					//MT: lock(password) // MultiThread safe				
					{
						password = value;
						if (null != PasswordChanged)
						{
							PasswordChanged(this, new EventArgs());
						}
						isPassword = password;
					}
				}
			} // Password.set
		} // Password

		/// <summary>
		/// private member field for holding Password data
		/// </summary>
		private
			bool
			password
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// PasswordChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			PasswordChanged
			;
		# endregion Property bool Password w Event post (PasswordChanged)
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		// MT.D only - needed for backward compatibility
		bool isPassword;
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property string Hint w Event post (HintChanged)
		/// <summary>
		/// Hint (MA.D only, not in MT.D)
		/// </summary>
		public
		  string
		  Hint
		{
			get
			{
				return hint;
			} // Hint.get
			set
			{
				//if (hint != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginning with //MT:
					//MT: lock(hint) // MultiThread safe				
					{
						hint = value;
						if (null != HintChanged)
						{
							HintChanged(this, new EventArgs());
						}
					}
				}
			} // Hint.set
		} // Hint

		/// <summary>
		/// private member field for holding Hint data
		/// </summary>
		private
			string
			hint
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// HintChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			HintChanged
			;
		# endregion Property string Hint w Event post (HintChanged)
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		# endregion Properites

		string placeholder; 

		public override string Summary()
		{
			return Value;
			// return value_entry_text;		// MA.D
		}
	}
}