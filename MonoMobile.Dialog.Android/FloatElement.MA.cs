using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MonoMobile.Dialog
{
	public partial class FloatElement : Element, SeekBar.IOnSeekBarChangeListener
	{
		// mc++ public bool ShowCaption;
		// mc++ public int Value;					// MT.D float!!!
		// mc++ public int MinValue, MaxValue;		// MT.D float!!!
		public Bitmap Left;
		public Bitmap Right;

		# region    Constructors
		//-------------------------------------------------------------------------
		public FloatElement(string caption)
			: this(caption, (int)ElementLayout.dialog_floatimage)
		{
			Value = 0;
			MinValue = 0;
			MaxValue = 10;
		}
		//-------------------------------------------------------------------------
		protected FloatElement(string caption, int layoutId)
			: base(caption, layoutId)
		{
			Value = 0;
			MinValue = 0;
			MaxValue = 10;
		}
		//-------------------------------------------------------------------------
		public FloatElement(float value, float min, float max)
			: this("", (int)ElementLayout.dialog_floatimage)
		{
			Value = value;
			MinValue = min;
			MaxValue = max;
		}
		//-------------------------------------------------------------------------
		// MT.D
		// public FloatElement(UIImage left, UIImage right, float value)
		// 	: base(null)
		// {
		// 	Left = left;
		// 	Right = right;
		// 	MinValue = 0;
		// 	MaxValue = 1;
		// 	Value = value;
		// }

		// mc++ public FloatElement(Bitmap left, Bitmap right, int value)
		public FloatElement(Bitmap left, Bitmap right, float value)
			: this(left, right, value, (int)ElementLayout.dialog_floatimage)
		{
			Left = left;
			Right = right;
			MinValue = 0;
			MaxValue = 1;
			Value = value;
		}
		//-------------------------------------------------------------------------
		// mc++ public FloatElement(Bitmap left, Bitmap right, int value, int layoutId)

		protected FloatElement(Bitmap left, Bitmap right, float value, int layoutId)
			: base(string.Empty, layoutId)
		{
			Left = left;
			Right = right;
			MinValue = 0;
			MaxValue = 10;
			Value = value;
		}
		//-------------------------------------------------------------------------
		# endregion Constructors
		


		public override View GetView(Context context, View convertView, ViewGroup parent)
		{
			TextView label;
			SeekBar slider;
			ImageView left;
			ImageView right;

			View view = DroidResources.LoadFloatElementLayout(context, convertView, parent, LayoutId, out label, out slider, out left, out right);

			if (view != null)
			{
				if (left != null)
				{
					if (Left != null)
						left.SetImageBitmap(Left);
					else
						left.Visibility = ViewStates.Gone;
				}
				if (right != null)
				{
					if (Right != null)
						right.SetImageBitmap(Right);
					else
						right.Visibility = ViewStates.Gone;
				}
				slider.Max = (int) Math.Round(MaxValue - MinValue);
				slider.Progress = (int) Math.Round(Value - MinValue);
				slider.SetOnSeekBarChangeListener(this);
				if (label != null)
				{
					if (ShowCaption)
						label.Text = Caption;
					else
						label.Visibility = ViewStates.Gone;
				}
			}
			else
			{
			global::Android.Util.Log.Error("FloatElement", "GetView failed to load template view");
			}

			return view;
		}

		void SeekBar.IOnSeekBarChangeListener.OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
		{
			Value = MinValue + progress;
		}

		void SeekBar.IOnSeekBarChangeListener.OnStartTrackingTouch(SeekBar seekBar)
		{
		}

		void SeekBar.IOnSeekBarChangeListener.OnStopTrackingTouch(SeekBar seekBar)
		{
		}
	}
}