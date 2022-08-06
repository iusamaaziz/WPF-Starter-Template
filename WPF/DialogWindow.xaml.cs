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
using System.Windows.Shapes;

namespace WPF
{
	/// <summary>
	/// Interaction logic for DialogWindow.xaml
	/// </summary>
	public partial class DialogWindow : Window
	{
		private DialogWindowViewModel mViewModel;

		public DialogWindowViewModel ViewModel
		{
			get => mViewModel;
			set
			{
				mViewModel = value;
				DataContext = mViewModel;
			}
		}

		public DialogWindow()
		{
			InitializeComponent();
		}
	}
}
