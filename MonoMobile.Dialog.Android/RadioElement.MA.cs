using System;
using Android.Content;
using Android.Views;

namespace MonoMobile.Dialog
{
	public partial class RadioElement : StringElement
	{


		public override View GetView(Context context, View convertView, ViewGroup parent)
		{
			if (!(((RootElement)Parent.Parent).group is RadioGroup))
				throw new Exception("The RootElement's Group is null or is not a RadioGroup");

			return base.GetView(context, convertView, parent);
		}

		public override string Summary()
		{
			return Caption;
		}
	}
}