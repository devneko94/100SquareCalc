using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _100SquareCalc
{
    public class CalcModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EnumCalcMode mode = (EnumCalcMode)value;

            switch (value)
            {
                case EnumCalcMode.Add:
                    return "＋";
                case EnumCalcMode.Sub:
                    return "－";
                case EnumCalcMode.Times:
                    return "×";
                case EnumCalcMode.Div:
                    return "÷";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strMode = (string)value;

            switch (value)
            {
                case "＋":
                    return EnumCalcMode.Add;
                case "－":
                    return EnumCalcMode.Sub;
                case "×":
                    return EnumCalcMode.Times;
                case "÷":
                    return EnumCalcMode.Div;
                default:
                    return EnumCalcMode.Add;
            }
        }
    }
}
