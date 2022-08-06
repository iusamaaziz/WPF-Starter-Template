using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

using WPF.ValueConvertors;

namespace WPF
{
	/// <summary>
	/// The View Model for the custom flat window
	/// </summary>
	public class MainWindowViewModel : BaseViewModel
	{
		#region Private Member

		/// <summary>
		/// The window this view model controls
		/// </summary>
		private Window mWindow;

		/// <summary>
		/// The margin around the window to allow for a drop shadow
		/// </summary>
		private int mOuterMarginSize = 1;

		/// <summary>
		/// The radius of the edges of the window
		/// </summary>
		private int mWindowRadius = 10;

		/// <summary>
		/// The last known dock position
		/// </summary>
		private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

		#endregion

		#region Public Properties

		/// <summary>
		/// The smallest width the window can go to
		/// </summary>
		public double WindowMinimumWidth { get; set; } = 300;

		/// <summary>
		/// The smallest height the window can go to
		/// </summary>
		public double WindowMinimumHeight { get; set; } = 400;

		/// <summary>
		/// True if the window should be borderless because it is docked or maximized
		/// </summary>
		public bool Borderless { get { return mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked; } }

		/// <summary>
		/// The size of the resize border around the window
		/// </summary>
		public int ResizeBorder { get; set; } = 5;

		/// <summary>
		/// The size of the resize border around the window, taking into account the outer margin
		/// </summary>
		public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

		/// <summary>
		/// The padding of the inner content of the main window
		/// </summary>
		public Thickness InnerContentPadding { get; set; } = new Thickness(0);

		/// <summary>
		/// The margin around the window to allow for a drop shadow
		/// </summary>
		public int OuterMarginSize
		{
			get =>
				// If it is maximized or docked, no border
				Borderless ? 0 : mOuterMarginSize;
			set => mOuterMarginSize = value;
		}

		/// <summary>
		/// The margin around the window to allow for a drop shadow
		/// </summary>
		public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

		/// <summary>
		/// The radius of the edges of the window
		/// </summary>
		public int WindowRadius
		{
			get =>
				// If it is maximized or docked, no border
				Borderless ? 0 : mWindowRadius;
			set => mWindowRadius = value;
		}

		/// <summary>
		/// The radius of the edges of the window
		/// </summary>
		public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

		/// <summary>
		/// The height of the title bar / caption of the window
		/// </summary>
		public int TitleHeight { get; set; } = 35;
		/// <summary>
		/// The height of the title bar / caption of the window
		/// </summary>
		public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

		public MainWindowPage CurrentPage { get; set; } = MainWindowPage.Login;

		public SideMenuItemViewModel CurrentButtonViewModel { get; set; } = new SideMenuItemDesignModel();


		/// <summary>
		/// To show whether internet is connected
		/// </summary>
		public bool IsConnected { get; set; } = true;

		public string NotificationText { get; set; }

		public bool IsNotification => !String.IsNullOrEmpty(NotificationText);

		public NotificationType NotificationType { get; set; }

		public Brush NotificationBackground => NotificationTypeToColorConvertor.Convert(NotificationType);

		public string ApplicationVersion { get; set; } = System.Windows.Forms.Application.ProductVersion.ToString();

		#endregion

		#region Commands

		/// <summary>
		/// The command to minimize the window
		/// </summary>
		public ICommand MinimizeCommand { get; set; }

		/// <summary>
		/// The command to maximize the window
		/// </summary>
		public ICommand MaximizeCommand { get; set; }

		/// <summary>
		/// The command to close the window
		/// </summary>
		public ICommand CloseCommand { get; set; }

		/// <summary>
		/// The command to show the system menu of the window
		/// </summary>
		public ICommand MenuCommand { get; set; }

		/// <summary>
		/// The command to close notification
		/// </summary>
		public ICommand CloseNotificationCommand { get; set; }

		public ICommand LogoutCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public MainWindowViewModel(Window window)
		{
			mWindow = window;

			// Listen out for the window resizing
			mWindow.StateChanged += (sender, e) =>
			{
				// Fire off events for all properties that are affected by a resize
				WindowResized();
			};

			// Create commands
			MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
			MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
			CloseCommand = new RelayCommand(() => mWindow.Close());
			MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));
			CloseNotificationCommand = new RelayCommand(() => NotificationText = string.Empty);
			LogoutCommand = new RelayCommand(async () => await LogoutAsync());


			// Fix window resize issue
			var resizer = new WindowResizer(mWindow);

			// Listen out for dock changes
			resizer.WindowDockChanged += (dock) =>
			{
				// Store last position
				mDockPosition = dock;

				// Fire off resize events
				WindowResized();
				// how are you r, im fine but not doing vey good.
			};
		}

		private Task LogoutAsync()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Private Helpers

		/// <summary>
		/// Gets the current mouse position on the screen
		/// </summary>
		/// <returns></returns>
		private Point GetMousePosition()
		{
			// Position of the mouse relative to the window
			var position = Mouse.GetPosition(mWindow);

			// Add the window position so its a "ToScreen"
			return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
		}

		/// <summary>
		/// If the window resizes to a special position (docked or maximized)
		/// this will update all required property change events to set the borders and radius values
		/// </summary>
		private void WindowResized()
		{
			// Fire off events for all properties that are affected by a resize
			OnPropertyChanged(nameof(Borderless));
			OnPropertyChanged(nameof(ResizeBorderThickness));
			OnPropertyChanged(nameof(OuterMarginSize));
			OnPropertyChanged(nameof(OuterMarginSizeThickness));
			OnPropertyChanged(nameof(WindowRadius));
			OnPropertyChanged(nameof(WindowCornerRadius));
		}


		#endregion
	}
}
