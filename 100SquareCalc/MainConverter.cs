using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

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
            throw new NotImplementedException();
        }
    }

    public class NormalCellColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? isCorrect = (bool?)value;

            switch (isCorrect)
            {
                case true:
                    return Brushes.LightGreen;
                case false:
                    return Brushes.IndianRed;
                default:
                    return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
