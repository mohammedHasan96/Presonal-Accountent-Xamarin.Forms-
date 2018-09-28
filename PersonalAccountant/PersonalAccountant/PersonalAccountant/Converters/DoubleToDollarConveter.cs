using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalAccountant.Converters
{
    public class DoubleToDollarConveter : IMarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => String.Format("{0:C}", value);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
        

        public object ProvideValue(IServiceProvider serviceProvider)
            => this;
    }
}
