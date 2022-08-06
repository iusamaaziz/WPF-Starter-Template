using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
{
	public class MessageBoxDialogViewModel : BaseDialogViewModel
	{
		/// <summary>
		/// The message to display
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// The text to use for the OK button
		/// </summary>
		public string OkText { get; set; }
		/// <summary>
		/// The value to check if there's need to close application when Ok button is clicked
		/// </summary>
		public bool IsFatalException { get; set; }

		public MessageBoxDialogViewModel(string message, bool isFatalExceptionMessage = false, string title = "Chef's RMP Kitchen", string buttonText = "Ok")
		{
			Title = title;
			Message = message;
			OkText = buttonText;
		}
	}
}
