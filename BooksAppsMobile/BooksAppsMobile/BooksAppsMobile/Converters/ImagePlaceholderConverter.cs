using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace BooksAppsMobile.Converters
{
    public class ImagePlaceholderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return ImageSource.FromUri(new Uri(value.ToString()));
            }
            return ImageSource.FromResource("BooksAppsMobile.Images.placeholder.jpg", typeof(ImagePlaceholderConverter).GetTypeInfo().Assembly);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
