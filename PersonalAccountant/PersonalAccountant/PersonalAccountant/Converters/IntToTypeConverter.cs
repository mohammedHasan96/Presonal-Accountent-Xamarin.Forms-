using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalAccountant.Converters
{
    public class IntToTypeConverter : IMarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            =>  (int)value == 0 ? "Expence" : "Income" ;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => (String)value == "Expence" ? 0 : 1;


        public object ProvideValue(IServiceProvider serviceProvider)
            => this;
    }
}
