using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
	public class InverseBooleanToVisibilityConvertor : BaseValueConvertor<InverseBooleanToVisibilityConvertor>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return parameter == null
				? (bool)value ? Visibility.Visible : Visibility.Collapsed
				: (bool)value ? Visibility.Collapsed : Visibility.Visible;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
