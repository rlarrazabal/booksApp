using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace BooksAppsMobile.Converters
{
    /// <summary>
    /// Converter to show the image from url and if no url is provided to show placeholder
    /// </summary>
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
