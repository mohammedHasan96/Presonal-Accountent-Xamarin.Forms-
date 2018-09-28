using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalAccountant.Converters
{
    class IntegerToBoolConverter : IMarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((int)value) == 1 ? true : false;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ((bool)value) == true ? 1 : 0;

        public object ProvideValue(IServiceProvider serviceProvider)
            => this;
    }
}
