using WindowsPhoneMvp;
using WindowsPhoneMvp.Phone;

namespace XSample.WP.moljac01.SamplePages
{
	[PresenterBinding(typeof(PageMVPPresenter))]
	public partial class PageMVP : MvpPhoneApplicationPage, IView<PageMVPModel>
	{
		public PageMVPModel Model
		{
			get { return this.Model(); }
		}

		public PageMVP()
		{
			InitializeComponent();
		}
	}
}