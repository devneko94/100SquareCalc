using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _100SquareCalc.ui
{
    /// <summary>
    /// TitleCell.xaml の相互作用ロジック
    /// </summary>
    public partial class TitleCell : UserControl
    {
        public string TitleCellText
        {
            get => (string)GetValue(TitleCellTextProperty);
            set => SetValue(TitleCellTextProperty, value);
        }

        public static readonly DependencyProperty TitleCellTextProperty = DependencyProperty.Register(
            nameof(TitleCellText), typeof(string), typeof(TitleCell), new PropertyMetadata(string.Empty));

        public TitleCell()
        {
            InitializeComponent();
        }
    }
}
