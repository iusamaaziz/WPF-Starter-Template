using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace WPF
{
	/// <summary>
	/// A page of application
	/// </summary>
	public enum ApplicationPage
	{
		Dashboard,
		GenerateLicenseKey,
		ViewLicenseKeys,
		ManageUsers,
		ChangePassword,
		ManageBlacklist,
		InjectScript,
		Profile,
		SendMessage,
		Transactions,
		LagAlPiso,
		Store,
		ResetRoot,
		BannedApps,
		ViewUser,
		ViewProduct,
		Activity,
		Changelog,
		ActiveUsers,
		Home,
		Devices,
		Installer
	}

	/// <summary>
	/// The application state as a view model
	/// </summary>
	public class ApplicationViewModel : BaseViewModel
	{
		#region Public

		public dynamic User { get; set; }
		public int RegistrationNumber { get; set; }

		#endregion

		#region Commands

		public ICommand OpenChangeLogCommand { get; set; }

		#endregion
		#region Constructor

		[Obsolete]
		public ApplicationViewModel()
		{
			//User = UserStore.Instance.CurrentUser;
		}


		#endregion

		/// <summary>
		/// The current page of the application
		/// </summary>
		public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Home;

		/// <summary>
		/// True if the side menu should be shown
		/// </summary>
		public bool SideMenuVisible { get; set; } = true;

	}
}
