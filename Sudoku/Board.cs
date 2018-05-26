using System;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Sudoku
{
    class Board : INotifyPropertyChanged
    {
        // Implemented from interface
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ObservableCollection<InnerGrid>> InnerGrids;

        private bool isValidValue = true;

        public ObservableCollection<ObservableCollection<InnerGrid>> GridInnerGrids
        {
            get { return InnerGrids; }
        }

        public bool IsValid
        {
            get { return isValidValue; }
        }

        public InnerGrid this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= InnerGrids.Count)
                    throw new ArgumentOutOfRangeException("row", row, "Invalid Row Index");

                if (col < 0 || col > InnerGrids.Count)
                    throw new ArgumentOutOfRangeException("col", col, "Invald Column Index");

                return InnerGrids[row][col];
            }
        }

        public Board(int size)
        {
            InnerGrids = new ObservableCollection<ObservableCollection<InnerGrid>>();

            for (int i = 0; i < size; i++)
            {
                ObservableCollection<InnerGrid> innerGrid = new ObservableCollection<InnerGrid>();
                for (int j = 0; j < size; j++)
                {
                    InnerGrid grid = new InnerGrid(size);
                    //grid.PropertyChanged += new PropertyChangedEventHandler(cellPropertyChanged);
                    innerGrid.Add(grid);
                }

                InnerGrids.Add(innerGrid);
            }
        }
    }
}
