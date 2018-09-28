using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalAccountant.Converters
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            string translation;
            try { translation = Values.ResourcesManager.GetString(Text); }
            catch { translation = null; }

            if (translation == null)
            {
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
            }
            return translation;
        }
    }
}
