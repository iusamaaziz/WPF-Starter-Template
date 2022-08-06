using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF
{
	public class SideMenuItemViewModel : BaseViewModel
	{
		public string Name { get; set; }

		public string IconName { get; set; }

		public bool IsActive { get; set; }

		public string VisibleTo { get; set; }

		#region Public Commands

		/// <summary>
		/// Opens the current message thread
		/// </summary>
		public ICommand OpenPageCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public SideMenuItemViewModel()
		{
			// Create commands
			OpenPageCommand = new RelayCommand(OpenPage);
		}

		#endregion

		#region Command Methods

		public void OpenPage()
		{
			if (IsActive) return;
			switch (Name)
			{
				case "Dashboard":
					IoC.Application.GoToPage(ApplicationPage.Dashboard);
					break;
				case "Inject Script":
					IoC.Application.GoToPage(ApplicationPage.InjectScript);
					break;
				case "Profile":
					IoC.Application.GoToPage(ApplicationPage.Profile);
					break;
				case "Store":
					IoC.Application.GoToPage(ApplicationPage.Store);
					break;
				case "Transactions":
					IoC.Application.GoToPage(ApplicationPage.Transactions);
					break;
				case "Activity Log":
					IoC.Application.GoToPage(ApplicationPage.Activity);
					break;
				case "Home":
					IoC.Application.GoToPage(ApplicationPage.Home);
					break;
				case "Devices":
					IoC.Application.GoToPage(ApplicationPage.Devices);
					break;
				case "Change Log":
					IoC.Application.GoToPage(ApplicationPage.Changelog);
					break;
				default:
					IsActive = true;
					break;
			}
			IsActive = true;
		}
		#endregion
	}
}
