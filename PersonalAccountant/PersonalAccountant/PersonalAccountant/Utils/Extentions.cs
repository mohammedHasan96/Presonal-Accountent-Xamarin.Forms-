using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace System
{
    public static class Extentions
    {
        public static String GetString(this String Text)
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

        public static Color ToColor(this int type)
            => type == 0 ? Color.FromHex(Values.Colors["Red"]) : Color.FromHex(Values.Colors["Green"]);

        public static Color ToColor(this bool type)
            => type ? Color.FromHex(Values.Colors["Green"]) : Color.FromHex(Values.Colors["Red"]);

        public static int ToInt(this bool type)
            => type ? 1 : 0;

        public static bool ToBool(this int type)
            => type == 1 ? true : false;

        public static bool IsNull(this String str)
            => String.IsNullOrWhiteSpace(str);

        public static String ToType(this bool type)
            => type ? "Income" : "Expense";

        public static void ReFill<T>(this ObservableCollection<T> dst, IEnumerable<T> items)
        {
            dst.Clear();
            foreach (var item in items)
                dst.Add(item);
        }
    }
}
