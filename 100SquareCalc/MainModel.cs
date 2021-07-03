using System;
using System.Collections.Generic;
using System.Linq;
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

    public class NormalCellData
    {
        public int RowIndex { get; set; }

        public int ColumnIndex { get; set; }

        public int? InputNum { get; set; }

        public bool? IsCorrect { get; set; }
    }
}
