using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace _100SquareCalc
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public EnumCalcMode CalcMode
        {
            get => _calcMode;
            set
            {
                _calcMode = value;
                onPropertyChanged();
         
            }
        }

        public ObservableCollection<TitleCellData> TitleRowList
        {
            get => _titleRowList;
            set
            {
                _titleRowList = value;
                onPropertyChanged();
            }
        }

        public ObservableCollection<TitleCellData> TitleColumnList
        {
            get => _titleColumnList;
            set
            {
                _titleColumnList = value;
                onPropertyChanged();
            }
        }

        public ObservableCollection<NormalCellData> CalcCellList
        {
            get => _calcCelltList;
            set
            {
                _calcCelltList = value;
                onPropertyChanged();
            }
        }

        
        public ICommand ChangeModeCommand { get; private set; }

        public ICommand ShuffleTitleCommand { get; private set; }

        public ICommand InitCommand { get; private set; }

        public ICommand CheckAnswerCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private int[] _titleRowNums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private int[] _titleColumnNums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private EnumCalcMode _calcMode = EnumCalcMode.Add;
        private ObservableCollection<TitleCellData> _titleRowList = new ObservableCollection<TitleCellData>();
        private ObservableCollection<TitleCellData> _titleColumnList = new ObservableCollection<TitleCellData>();
        private ObservableCollection<NormalCellData> _calcCelltList = new ObservableCollection<NormalCellData>();

        public MainViewModel()
        {
            setTitleRowList();
            setTitleColumnList();
            setCalcCellList();
            ChangeModeCommand = new DelegateCommand(changeModeCommand);
            ShuffleTitleCommand = new DelegateCommand(shuffleTitleCommand);
            InitCommand = new DelegateCommand(initCommand);
            CheckAnswerCommand = new DelegateCommand(checkAnswerCommand);
        }

        private void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void setTitleRowList()
        {
            TitleRowList.Clear();

            for (int i = 0; i < 10; i++)
            {
                TitleCellData cell = new TitleCellData();
                cell.ColumnIndex = i;
                cell.TitleNum = _titleRowNums[i];
                TitleRowList.Add(cell);
            }
        }

        private void setTitleColumnList()
        {
            TitleColumnList.Clear();

            for (int i = 0; i < 10; i++)
            {
                TitleCellData cell = new TitleCellData();
                cell.RowIndex = i;
                cell.TitleNum = _titleColumnNums[i];
                TitleColumnList.Add(cell);
            }
        }

        private void setCalcCellList()
        {
            CalcCellList.Clear();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    NormalCellData cell = new NormalCellData();
                    cell.RowIndex = i;
                    cell.ColumnIndex = j;
                    CalcCellList.Add(cell);
                }
            }
        }

        private void changeModeCommand()
        {
            switch (CalcMode)
            {
                case EnumCalcMode.Add:
                    CalcMode = EnumCalcMode.Sub;
                    break;
                case EnumCalcMode.Sub:
                    CalcMode = EnumCalcMode.Times;
                    break;
                case EnumCalcMode.Times:
                    CalcMode = EnumCalcMode.Div;
                    break;
                case EnumCalcMode.Div:
                    CalcMode = EnumCalcMode.Add;
                    break;
                default:
                    CalcMode = EnumCalcMode.Add;
                    break;
            }
        }

        private void shuffleTitleCommand()
        {
            _titleRowNums = _titleRowNums.OrderBy(item => Guid.NewGuid()).ToArray();
            _titleColumnNums = _titleColumnNums.OrderBy(item => Guid.NewGuid()).ToArray();

            setTitleRowList();
            setTitleColumnList();
        }

        private void initCommand()
        {
            _titleRowNums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _titleColumnNums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            CalcMode = EnumCalcMode.Add;

            setTitleRowList();
            setTitleColumnList();
            setCalcCellList();
        }

        private void checkAnswerCommand()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int? answer;

                    switch (CalcMode)
                    {
                        case EnumCalcMode.Add:
                            answer = TitleRowList.Where(item => item.ColumnIndex == j).First().TitleNum.Value
                                    + TitleColumnList.Where(item => item.RowIndex == i).First().TitleNum.Value;
                            break;
                        case EnumCalcMode.Sub:
                            answer = TitleRowList.Where(item => item.ColumnIndex == j).First().TitleNum.Value
                                    - TitleColumnList.Where(item => item.RowIndex == i).First().TitleNum.Value;
                            break;
                        case EnumCalcMode.Times:
                            answer = TitleRowList.Where(item => item.ColumnIndex == j).First().TitleNum.Value
                                    * TitleColumnList.Where(item => item.RowIndex == i).First().TitleNum.Value;
                            break;
                        case EnumCalcMode.Div:
                            answer = TitleRowList.Where(item => item.ColumnIndex == j).First().TitleNum.Value
                                    / TitleColumnList.Where(item => item.RowIndex == i).First().TitleNum.Value;
                            break;
                        default:
                            answer = null;
                            break;
                    }

                    NormalCellData cellData = CalcCellList.Where(item => item.RowIndex == i && item.ColumnIndex == j).First();
                    
                    if (cellData.InputNum == answer)
                    {
                        cellData.IsCorrect = true;
                    }
                    else
                    {
                        cellData.IsCorrect = false;
                    }
                }
            }
        }
    }

    public enum EnumCalcMode
    {
        Add,
        Sub,
        Times,
        Div
    }

    public class DelegateCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action execute) : this(execute, () => true) { }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute();
        }

        public void Execute(object parameter)
        {
            this._execute();
        }
    }
}
