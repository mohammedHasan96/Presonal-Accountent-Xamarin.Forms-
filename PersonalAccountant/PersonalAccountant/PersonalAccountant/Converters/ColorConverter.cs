using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalAccountant.Converters
{
    [ContentProperty("Value")]
    class ColorConverter : IMarkupExtension
    {
        public String Value { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Color.FromHex(Values.Colors[Value]);
        }
    }
}
