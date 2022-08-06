using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
	/// <summary>
	/// The UI manager that handles any UI interaction in the application
	/// </summary>
	public interface IUIManager
	{
		/// <summary>
		/// Displays a single message box to the user
		/// </summary>
		/// <param name="viewModel">The view model</param>
		/// <returns></returns>
		Task ShowMessage(MessageBoxDialogViewModel viewModel);
		Task ShowMessage(string message, bool isFatalExceptionMessage = false, string title = "Chef's RMP Kitchen", string okText = "Ok!");

	}
}
