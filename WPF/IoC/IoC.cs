using Ninject;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
	/// <summary>
	/// The IoC container for our application
	/// </summary>
	public static class IoC
	{
		#region Public Properties

		/// <summary>
		/// The kernel for our IoC container
		/// </summary>
		public static IKernel Kernel { get; private set; } = new StandardKernel();

		/// <summary>
		/// A shortcut to access the <see cref="IUIManager"/>
		/// </summary>
		public static IUIManager UI => IoC.Get<IUIManager>();

		/// <summary>
		/// A shortcut to access the <see cref="ApplicationViewModel"/>
		/// </summary>
		public static AppViewModel Application => IoC.Get<AppViewModel>();

		public static ApplicationWindowViewModel ApplicationWindow => IoC.Get<ApplicationWindowViewModel>();

		#endregion

		#region Construction

		/// <summary>
		/// Sets up the IoC container, binds all information required and is ready for use
		/// NOTE: Must be called as soon as your application starts up to ensure all 
		///       services can be found
		/// </summary>
		public static void Setup()
		{
			// Bind all required view models
			BindViewModels();
		}

		/// <summary>
		/// Binds all singleton view models
		/// </summary>
		private static void BindViewModels()
		{
			// Bind to a single instance of Application view model
			Kernel.Bind<AppViewModel>().ToConstant(new AppViewModel());

			Kernel.Bind<ApplicationWindowViewModel>().ToConstant(new ApplicationWindowViewModel());
		}

		#endregion

		/// <summary>
		/// Get's a service from the IoC, of the specified type
		/// </summary>
		/// <typeparam name="T">The type to get</typeparam>
		/// <returns></returns>
		public static T Get<T>()
		{
			return Kernel.Get<T>();
		}
	}
}
