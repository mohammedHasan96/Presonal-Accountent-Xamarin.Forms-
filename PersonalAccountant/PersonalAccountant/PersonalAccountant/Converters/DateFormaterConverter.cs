using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalAccountant.Converters
{
    public class DateFormaterConverter : IMarkupExtension, IValueConverter
    {
        public bool TrDate { get; set; } = false;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => TrDate ? (value as Nullable<DateTime>)?.ToString("dddd dd MMMM yyyy") : (value as Nullable<DateTime>)?.ToString("dd-MM-yyyy");

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
            => this;
    }
}
