using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormsDemo
{
	public class NullToBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var inverse = parameter != null && parameter.ToString().Equals("I", StringComparison.OrdinalIgnoreCase);
			bool result;
			if (value is string)
			{
				result =  string.IsNullOrEmpty((string)value);
			}

			result =  value == null;

			return inverse ? !result : result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
