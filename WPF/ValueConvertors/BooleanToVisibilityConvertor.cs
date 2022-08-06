using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF
{
	public class BooleanToVisibilityConvertor : BaseValueConvertor<BooleanToVisibilityConvertor>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return parameter == null
				? (bool)value ? Visibility.Collapsed : Visibility.Visible
				: (bool)value ? Visibility.Visible : Visibility.Collapsed;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
