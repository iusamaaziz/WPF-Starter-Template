using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF
{
	public class DialogWindowViewModel : BaseDialogViewModel
	{
		#region PublicProperties

		/// <summary>
		/// The title of this dialog window
		/// </summary>
		public Control Content { get; set; }

		#endregion

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
		public double WindowMinimumWidth { get; set; } = 250;

		/// <summary>
		/// The smallest height the window can go to
		/// </summary>
		public double WindowMinimumHeight { get; set; } = 100;

		/// <summary>
		/// True if the window should be borderless because it is docked or maximized
		/// </summary>
		public bool Borderless { get { return mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked; } }

		/// <summary>
		/// The size of the resize border around the window
		/// </summary>
		public int ResizeBorder { get; set; } = 1;

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
		public int TitleHeight { get; set; } = 30;
		/// <summary>
		/// The height of the title bar / caption of the window
		/// </summary>
		public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

		public ICommand CloseCommand { get; set; }

		#endregion

		#region Constructor
		public DialogWindowViewModel(Window window)
		{
			mWindow = window;

			CloseCommand = new RelayCommand(() => mWindow.Close());
		}
		#endregion
	}
}
