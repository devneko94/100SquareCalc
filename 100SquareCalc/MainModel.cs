using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _100SquareCalc
{
    public class TitleCellData
    {
        public int RowIndex { get; set; }

        public int ColumnIndex { get; set; }

        public int? TitleNum { get; set; }
    }

    public class NormalCellData : INotifyPropertyChanged
    {
        public int RowIndex { get; set; }

        public int ColumnIndex { get; set; }

        public int? InputNum { get; set; }

        private bool? _isCorrect = null;
        public bool? IsCorrect
        {
            get => _isCorrect;
            set
            {
                _isCorrect = value;
                onPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
