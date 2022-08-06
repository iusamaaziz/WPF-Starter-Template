using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using WPF.ValueConvertors;

namespace WPF
{
	public class LoginViewModel : BaseViewModel
	{
		#region Public

		public string UserName { get; set; }

		public string Password { get; set; }

		public bool IsPasswordVisible { get; set; }

		public string GenericError { get; set; }

		public bool IsGenericError => GenericError?.Length > 4;

		public bool CanLogin => UserName?.Length >= 3 && Password?.Length >= 3;

		public bool IsProcessing { get; set; }

		#endregion

		#region Commands

		/// <summary>
		/// The command to login
		/// </summary>
		public ICommand LoginCommand { get; set; }

		public ICommand SwitchPasswordVisibilityCommand { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		[Obsolete]
		public LoginViewModel()
		{
			// Create commands
			LoginCommand = new RelayCommand(async () => await PerformLoginAsync());
			SwitchPasswordVisibilityCommand = new RelayCommand(SwitchPasswordVisibility);
		}

		#endregion

		#region Private Helpers

		[Obsolete]
		private async Task PerformLoginAsync()
		{
			if (IsProcessing)
				return;

			IsPasswordVisible = false;
			IsProcessing = true;
			Logger.Log("Trying to login", Microsoft.Extensions.Logging.LogLevel.Information);
			IoC.ApplicationWindow.GoToPage(MainWindowPage.Main);

			IsProcessing = false;
			await ClearErrorMessagesAsync();
		}

		private void SwitchPasswordVisibility()
		{
			IsPasswordVisible ^= true;
		}

		private async Task ClearErrorMessagesAsync()
		{
			await Task.Delay(3000);
			GenericError = String.Empty;
		}

		#endregion
	}
}
