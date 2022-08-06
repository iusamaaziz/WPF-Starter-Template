using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using WPF.Animation;

namespace WPF
{
	/// <summary>
	/// A base page for all pages to gain base functionality
	/// </summary>
	public class BasePage<VM> : Page
		where VM : BaseViewModel, new()
	{
		#region Private Member

		/// <summary>
		/// The View Model associated with this page
		/// </summary>
		private VM mViewModel;

		#endregion

		#region Public Properties

		/// <summary>
		/// The animation the play when the page is first loaded
		/// </summary>
		public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

		/// <summary>
		/// The animation the play when the page is unloaded
		/// </summary>
		public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

		/// <summary>
		/// The time any slide animation takes to complete
		/// </summary>
		public float SlideSeconds { get; set; } = 0.8f;

		/// <summary>
		/// The View Model associated with this page
		/// </summary>
		public VM ViewModel
		{
			get { return mViewModel; }
			set
			{
				// If nothing has changed, return
				if (mViewModel == value)
					return;

				// Update the value
				mViewModel = value;

				// Set the data context for this page
				this.DataContext = mViewModel;
			}
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public BasePage()
		{
			// If we are animating in, hide to begin with
			if (this.PageLoadAnimation != PageAnimation.None)
				this.Visibility = Visibility.Collapsed;

			// Listen out for the page loading
			this.Loaded += BasePage_LoadedAsync;

			// Create a default view model
			this.ViewModel = new VM();

		}

		/// <summary>
		/// ViewModel Parameterized constructor
		/// </summary>
		public BasePage(BaseViewModel viewModel)
		{
			// If we are animating in, hide to begin with
			if (this.PageLoadAnimation != PageAnimation.None)
				this.Visibility = Visibility.Collapsed;

			// Listen out for the page loading
			this.Loaded += BasePage_LoadedAsync;

			// Create a default view model
			this.ViewModel = viewModel as VM;
		}

		#endregion

		#region Animation Load / Unload

		/// <summary>
		/// Once the page is loaded, perform any required animation
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
		{
			// Animate the page in
			await AnimateIn();
		}

		/// <summary>
		/// Animates the page in
		/// </summary>
		/// <returns></returns>
		public async Task AnimateIn()
		{
			// Make sure we have something to do
			if (this.PageLoadAnimation == PageAnimation.None)
				return;

			switch (this.PageLoadAnimation)
			{
				case PageAnimation.SlideAndFadeInFromRight:

					// Start the animation
					await PageAnimations.SlideAndFadeInFromRightAsync(this, SlideSeconds);

					break;
			}
		}

		/// <summary>
		/// Animates the page out
		/// </summary>
		/// <returns></returns>
		public async Task AnimateOut()
		{
			// Make sure we have something to do
			if (this.PageUnloadAnimation == PageAnimation.None)
				return;

			switch (this.PageUnloadAnimation)
			{
				case PageAnimation.SlideAndFadeOutToLeft:

					// Start the animation
					await PageAnimations.SlideAndFadeOutToLeftAsync(this, SlideSeconds);

					break;
			}
		}

		#endregion
	}
}
