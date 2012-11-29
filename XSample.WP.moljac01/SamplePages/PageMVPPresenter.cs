using System;
using WindowsPhoneMvp;

namespace XSample.WP.moljac01.SamplePages
{
	public class PageMVPPresenter : Presenter<IView<PageMVPModel>, PageMVPModel>
	{
		public PageMVPPresenter(IView<PageMVPModel> view)
			: base(view)
		{
			View.Load += View_Load;
		}

		void View_Load(object sender, EventArgs e)
		{

		}
	}
}
