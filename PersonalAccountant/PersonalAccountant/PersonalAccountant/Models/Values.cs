using System.Collections.Generic;
using System.Resources;
using Xamarin.Forms;

namespace System
{
    public class Values
    {
        public static ResourceManager ResourcesManager { get; set; }
        public static FlowDirection FlowDirection { get; } = Device.FlowDirection;
        public static double Balance { get; set; } = 0;
        public static double Income { get; set; } = 0;
        public static double Expence { get; set; } = 0;
        public static int MyProperty { get; set; }
        public static Dictionary<String, String> Colors { get; } = new Dictionary<string, string>
        {
            ["Blue"] = "#2196F3",
            ["Red"] = "#F44336",
            ["Green"] = "#4CAF50",
            ["Background"] = "#d2dae2",
            ["BText"] = "#212121",
            ["SText"] = "#757575",
            ["GreenButt"] = "#DCEDC8",
            ["Text"] = "#FFFFFF",
            ["OnColor"] = "#C8E6C9"
        }; 
            
    }
}
