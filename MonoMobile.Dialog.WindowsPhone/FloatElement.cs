using System;
using System.Collections;
using System.Collections.Generic;

namespace MonoMobile.Dialog
{
	public partial class FloatElement
		: Element
	{
		# region    Properites
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property bool ShowCaption w Event post (ShowCaptionChanged)
		/// <summary>
		/// ShowCaption
		/// </summary>
		public
		  bool
		  ShowCaption
		{
			get
			{
				return show_caption;
			} // ShowCaption.get
			set
			{
				//if (show_caption != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginning with //MT:
					//MT: lock(show_caption) // MultiThread safe				
					{
						show_caption = value;
						if (null != ShowCaptionChanged)
						{
							ShowCaptionChanged(this, new EventArgs());
						}
					}
				}
			} // ShowCaption.set
		} // ShowCaption

		/// <summary>
		/// private member field for holding ShowCaption data
		/// </summary>
		private
			bool
			show_caption
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// ShowCaptionChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			ShowCaptionChanged
			;
		# endregion Property bool ShowCaption w Event post (ShowCaptionChanged)
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property float Value w Event post (ValueChanged)
		/// <summary>
		/// Value
		/// </summary>
		public
		  float
		  Value
		{
			get
			{
				return value_slider;
			} // Value.get
			set
			{
				//if (value_slider != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginning with //MT:
					//MT: lock(value_slider) // MultiThread safe				
					{
						value_slider = value;
						if (null != ValueChanged)
						{
							ValueChanged(this, new EventArgs());
						}
					}
				}
			} // Value.set
		} // Value

		/// <summary>
		/// private member field for holding Value data
		/// </summary>
		private
			float
			value_slider
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
		# endregion Property float Value w Event post (ValueChanged)
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property float MinValue w Event post (MinValueChanged)
		/// <summary>
		/// MinValue
		/// </summary>
		public
		  float
		  MinValue
		{
			get
			{
				return min_value;
			} // MinValue.get
			set
			{
				//if (min_value != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginning with //MT:
					//MT: lock(min_value) // MultiThread safe				
					{
						min_value = value;
						if (null != MinValueChanged)
						{
							MinValueChanged(this, new EventArgs());
						}
					}
				}
			} // MinValue.set
		} // MinValue

		/// <summary>
		/// private member field for holding MinValue data
		/// </summary>
		private
			float
			min_value
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// MinValueChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			MinValueChanged
			;
		# endregion Property float MinValue w Event post (MinValueChanged)
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# region Property float MaxValue w Event post (MaxValueChanged)
		/// <summary>
		/// MaxValue
		/// </summary>
		public
		  float
		  MaxValue
		{
			get
			{
				return max_vlaue;
			} // MaxValue.get
			set
			{
				//if (max_vlaue != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginning with //MT:
					//MT: lock(max_vlaue) // MultiThread safe				
					{
						max_vlaue = value;
						if (null != MaxValueChanged)
						{
							MaxValueChanged(this, new EventArgs());
						}
					}
				}
			} // MaxValue.set
		} // MaxValue

		/// <summary>
		/// private member field for holding MaxValue data
		/// </summary>
		private
			float
			max_vlaue
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// MaxValueChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			MaxValueChanged
			;
		# endregion Property float MaxValue w Event post (MaxValueChanged)
		//-------------------------------------------------------------------------

		//-------------------------------------------------------------------------
		# endregion Properites


		/// <summary>
		/// MT.D only
		/// MA.D missing - this is fix in common file
		/// </summary>
		/// <returns></returns>
		public override string Summary()
		{
			return Value.ToString();
		}

	}
}