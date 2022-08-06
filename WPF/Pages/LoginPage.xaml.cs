using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WPF.Animation;

namespace WPF
{
	/// <summary>
	/// Interaction logic for LoginPage.xaml
	/// </summary>
	public partial class LoginPage : BasePage<LoginViewModel>
	{
		public LoginPage()
		{
			InitializeComponent();

			Password.Password = VisiblePassword.Text;
		}

		private async void SignUp_Click(object sender, RoutedEventArgs e)
		{
			await this.SlideAndFadeOutToLeftAsync(0.6f);
			IoC.ApplicationWindow.GoToPage(MainWindowPage.SignUp);
		}

		private async void ForgotPassword_Click(object sender, RoutedEventArgs e)
		{
			await this.SlideAndFadeOutToLeftAsync(0.6f);
			IoC.ApplicationWindow.GoToPage(MainWindowPage.ForgotPassword);
		}

		private void Password_PasswordChanged(object sender, RoutedEventArgs e)
		{
			if (DataContext != null)
			{ ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
		}

		private void VisiblePassword_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void Username_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				Password.Focus();
			}
		}

		private void VisiblePassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				LoginButton.Focus();
			}
		}

		private void Password_LostFocus(object sender, RoutedEventArgs e)
		{
			if (DataContext != null)
			{ ((dynamic)DataContext).IsPasswordVisible = false; }
			Password.Password = VisiblePassword.Text;
		}

		private void Remember_Click(object sender, RoutedEventArgs e)
		{
			if (DataContext != null)
			{ ((dynamic)DataContext).IsPasswordVisible = false; }
		}
	}
}
