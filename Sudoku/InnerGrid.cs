using System;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Sudoku
{
    class InnerGrid : INotifyPropertyChanged
    {
        // Implemented from interface
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ObservableCollection<Cell>> Rows;

        private bool isValidValue = true;

        public ObservableCollection<ObservableCollection<Cell>> GridRows
        {
            get { return Rows; }
        }

        public bool IsValid
        {
            get { return isValidValue; }
        }

        public Cell this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows.Count)
                    throw new ArgumentOutOfRangeException("row", row, "Invalid Row Index");

                if (col < 0 || col > Rows.Count)
                    throw new ArgumentOutOfRangeException("col", col, "Invald Column Index");

                return Rows[row][col];
            }
        }

        public InnerGrid(int size)
        {
            Rows = new ObservableCollection<ObservableCollection<Cell>>();

            for (int i = 0; i < size; i++)
            {
                ObservableCollection<Cell> collumn = new ObservableCollection<Cell>();
                for (int j = 0; j < size; j++)
                {
                    Cell cell = new Cell();
                    // TODO: Check this shit
                    cell.PropertyChanged += new PropertyChangedEventHandler(cellPropertyChanged);
                    collumn.Add(cell);
                }

                Rows.Add(collumn);
            }
        }

        private void cellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                bool valid = checkIsValid();

                foreach (ObservableCollection<Cell> row in Rows)
                {
                    foreach(Cell cell in row)
                    {
                        cell.IsValid = valid;
                    }
                }
                
                isValidValue = valid;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
                }
            }
        }

        private bool checkIsValid()
        {
            bool[] used = new bool[Rows.Count * Rows.Count];

            foreach(ObservableCollection<Cell> row in Rows)
            {
                foreach(Cell cell in row)
                {
                    if (cell.Value.HasValue)
                    {
                        if (used[cell.Value.Value - 1])
                        {
                            return false;
                        }

                        used[cell.Value.Value - 1] = true;
                    }
                }
            }

            return true;
        }
    }
}
