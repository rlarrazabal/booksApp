using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BooksAppsMobile.Converters
{
    public class ItemTappedEventArgsToItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is ItemTappedEventArgs eventArgs)
            {
                return eventArgs.Item;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new ItemTappedEventArgs(value,value,(int)parameter);
        }
    }
}
