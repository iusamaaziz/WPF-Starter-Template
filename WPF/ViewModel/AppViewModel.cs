using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF
{
	public class AppViewModel : BaseViewModel
	{
		public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
		{
			if (viewModel != null)
			{
				viewModel.StopDispatcher();
			}

			((((MainWindow)Application.Current.MainWindow).MainFrame.Content as MainPage).DataContext as ApplicationViewModel).CurrentPage = page;

			//((MainWindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = page;

			// Create Page with passed viewModel
			//((MainWindow)Application.Current.MainWindow).MainFrame.Content = new ApplicationPageValueConvertor().Convert(page, parameter: viewModel == null ? null : viewModel);
			//if (viewModel != null)
			((((MainWindow)Application.Current.MainWindow).MainFrame.Content as MainPage).ContentFrame.Content as Page).DataContext = viewModel;

			// Set the current page
			//CurrentPage = page;
			// Fire off a CurrentPage changed event
			//OnPropertyChanged(nameof(CurrentPage));

			// Set the view model
			//CurrentPageViewModel = viewModel;


			// Show side menu or not?
			//SideMenuVisible = page == ApplicationPage.Chat;
			//SideMenuVisible = true;

			SideMenuListViewModel.Items.ForEach(a => a.IsActive = false);

		}

		public static BaseViewModel CurrentPageViewModel { get; set; }

	}
}
