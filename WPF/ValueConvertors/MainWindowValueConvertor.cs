using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
	/// <summary>
	/// Converts the <see cref="MainWindowPage"/> to an actual view/page
	/// </summary>
	public class MainWindowValueConvertor : BaseValueConvertor<MainWindowValueConvertor>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch ((MainWindowPage)value)
			{
				case MainWindowPage.Login:
					return new LoginPage();
				case MainWindowPage.SignUp:
					return new SignUpPage();
				case MainWindowPage.Main:
					return new MainPage();
				//case MainWindowPage.ForgotPassword:
				//    page = PageStore.GetPageByKey("ForgotPassword");
				//    return page == null ? new ForgotPasswordPage() : page.Item1;
				//case MainWindowPage.Main:
				//    page = PageStore.GetPageByKey("Main");
				//    return page == null ? new MainPage() : page.Item1;
				//case MainWindowPage.TermsAndConditions:
				//    page = PageStore.GetPageByKey("TermsAndConditions");
				//    return page == null ? new TermsAndConditionsPage() : page.Item1;
				default:
					Debugger.Break();
					return null;
			}
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
