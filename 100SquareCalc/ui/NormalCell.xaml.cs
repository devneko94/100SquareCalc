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
    /// NormalCell.xaml の相互作用ロジック
    /// </summary>
    public partial class NormalCell : UserControl
    {
        public Brush NormalCellColor
        {
            get => (Brush)GetValue(NormalCellColorProperty);
            set => SetValue(NormalCellColorProperty, value);
        }

        public static readonly DependencyProperty NormalCellColorProperty = DependencyProperty.Register(
                nameof(NormalCellColor), typeof(Brush), typeof(NormalCell), new PropertyMetadata(Brushes.Transparent));

        public string NormalCellText
        {
            get => (string)GetValue(NormalCellTextProperty);
            set => SetValue(NormalCellTextProperty, value);
        }

        public static readonly DependencyProperty NormalCellTextProperty = DependencyProperty.Register(
                nameof(NormalCellText), typeof(string), typeof(NormalCell), new PropertyMetadata(string.Empty));

        public NormalCell()
        {
            InitializeComponent();
        }
    }
}
