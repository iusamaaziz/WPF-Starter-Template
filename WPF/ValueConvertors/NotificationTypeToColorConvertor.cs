using System;
using System.Globalization;
using System.Windows.Media;

namespace WPF.ValueConvertors
{
	public enum NotificationType
	{
		Success,
		Error,
		Information,
		Warning
	}

	public class NotificationTypeToColorConvertor : BaseValueConvertor<NotificationTypeToColorConvertor>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch ((NotificationType)value)
			{
				case NotificationType.Success:
					return Brushes.ForestGreen;
				case NotificationType.Error:
					return Brushes.OrangeRed;
				case NotificationType.Information:
					return Brushes.CornflowerBlue;
				case NotificationType.Warning:
					return Brushes.LightGoldenrodYellow;
				default:
					return Brushes.Black;
			}
		}

		public static Brush Convert(NotificationType value)
		{
			switch (value)
			{
				case NotificationType.Success:
					return Brushes.ForestGreen;
				case NotificationType.Error:
					return Brushes.IndianRed;
				case NotificationType.Information:
					return Brushes.CornflowerBlue;
				case NotificationType.Warning:
					return Brushes.YellowGreen;
				default:
					return Brushes.Black;
			}
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
