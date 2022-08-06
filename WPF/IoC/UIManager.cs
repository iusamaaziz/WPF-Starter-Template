using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
	public class UIManager : IUIManager
	{
		public Task ShowMessage(MessageBoxDialogViewModel viewModel)
		{
			return new DialogMessageBox().ShowDialog(viewModel);
		}

		public Task ShowMessage(string message, bool isFatalExceptionMessage = false, string title = "Chef's RMP Kitchen", string okText = "Ok!")
		{
			return new DialogMessageBox().ShowDialog(new MessageBoxDialogViewModel(message, isFatalExceptionMessage, title, okText));
		}
	}
}
