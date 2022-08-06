using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
	/// <summary>
	/// A page of application
	/// </summary>
	public enum MainWindowPage
	{
		Login,
		SignUp,
		ForgotPassword,
		Main,
		TermsAndConditions
	}

	/// <summary>
	/// The application state as a view model
	/// </summary>
	public class ApplicationWindowViewModel : BaseViewModel
	{
		/// <summary>
		/// The current page of the application
		/// </summary>
		public MainWindowPage CurrentPage { get; private set; } = MainWindowPage.Main;


		/// <summary>
		/// The view model to use for the current page when the CurrentPage changes
		/// NOTE: This is not a live up-to-date view model of the current page
		///       it is simply used to set the view model of the current page 
		///       at the time it changes
		/// </summary>
		public BaseViewModel CurrentPageViewModel { get; set; }

		/// <summary>
		/// Navigates to the specified page
		/// </summary>
		/// <param name="page">The page to go to</param>
		public void GoToPage(MainWindowPage page, BaseViewModel viewModel = null)
		{
			// SettingsMenuVisible = false;

			// Set the view model
			CurrentPageViewModel = viewModel;

			CurrentPage = page;


			((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = page;

			//if (viewModel != null)
			//{
			//	((MainWindow)Application.Current.MainWindow).MainFrame.Content = new MainWindowValueConvertor().Convert(page, null, viewModel, null);
			//}
			//else
			//{
			//	((MainWindow)Application.Current.MainWindow).MainFrame.Content = new MainWindowValueConvertor().Convert(page, null, null, null);
			//}

			// Set the current page
			//CurrentPage = page;

			// Fire off a CurrentPage changed event
			OnPropertyChanged(nameof(CurrentPage));

			// Show side menu or not?
			//SideMenuVisible = page == ApplicationPage.Chat;
		}

	}
}
