using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace WPF
{
	/// <summary>
	/// Converts the <see cref="ApplicationPage"/> to an actual view/page
	/// </summary>
	public class ApplicationPageValueConvertor : BaseValueConvertor<ApplicationPageValueConvertor>
	{
		public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
		{
			return null;
			/*
            switch ((ApplicationPage)value)
            {
                default:
                    Debugger.Break();
                    return null;
                case ApplicationPage.Dashboard:
                    var page = PageStore.GetPageByKey("Dashboard");
                    return page == null ? new DashboardPage() : page.Item1;
                case ApplicationPage.Home:
                    page = PageStore.GetPageByKey("Home");
                    return page == null ? new HomePage() : page.Item1;
                case ApplicationPage.InjectScript:
                    return new InjectionPage();
                //page = PageStore.GetPageByKey("InjectScript");
                //return page == null ? new InjectionPage() : page.Item1;
                case ApplicationPage.Profile:
                    page = PageStore.GetPageByKey("Profile");
                    return page == null ? new ProfilePage() : page.Item1;
case ApplicationPage.Store:
                    page = PageStore.GetPageByKey("Store");
                    return page == null ? new StorePage() : page.Item1;
                case ApplicationPage.ResetRoot:
                    page = PageStore.GetPageByKey("ResetRoot");
                    return page == null ? new ResetRootPage() : page.Item1;
                case ApplicationPage.BannedApps:
                    page = PageStore.GetPageByKey("BannedApps");
                    return page == null ? new BannedAppsPage() : page.Item1;
                case ApplicationPage.ViewUser:
                    page = PageStore.GetPageByKey("ViewUser");
                    if (page != null) PageStore.RemovePageFromDictionary("ViewUser");
                    return page == null ? new ViewUserPage(parameter as ViewUserViewModel) : page.Item1;
                case ApplicationPage.ViewProduct:
                    page = PageStore.GetPageByKey("ViewProduct");
                    if (page != null) PageStore.RemovePageFromDictionary("ViewProduct");
                    return page == null ? new ViewProductPage(parameter as ViewProductViewModel) : page.Item1;
                case ApplicationPage.Transactions:
                    page = PageStore.GetPageByKey("Transactions");
                    return page == null ? new TransactionsPage() : page.Item1;
                case ApplicationPage.Activity:
                    page = PageStore.GetPageByKey("Activity");
                    return page == null ? new ActivityPage() : page.Item1;
                case ApplicationPage.Changelog:
                    return new ChangeLogPage();
                case ApplicationPage.ActiveUsers:
                    return new ActiveUsersPage();
                case ApplicationPage.Devices:
                    return new DevicesPage();
                case ApplicationPage.Installer:
                    page = PageStore.GetPageByKey("Installer");
                    if (page != null) PageStore.RemovePageFromDictionary("Installer");
                    return page == null ? new InstallerPage(parameter as InstallerViewModel) : page.Item1;
            }
			*/
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
