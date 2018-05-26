using System;
using System.ComponentModel;

namespace Sudoku
{
    class Cell : INotifyPropertyChanged
    {
        // Implemented from interface
        public event PropertyChangedEventHandler PropertyChanged;

        private bool readOnlyValue = false;
        private bool isValidValue = true;
        private int? valueValue = null;

        public bool ReadOnly
        {
            get { return readOnlyValue; }
            set
            {
                if (readOnlyValue != value)
                {
                    readOnlyValue = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ReadOnly"));
                    }
                }
            }
        }

        public int? Value
        {
            get { return valueValue; }
            set
            {
                if (valueValue != value)
                {
                    valueValue = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                    }
                }
            }
        }

        public bool IsValid
        {
            get { return isValidValue; }
            set
            {
                if (isValidValue != value)
                {
                    isValidValue = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
                    }
                }
            }
        }
    }
}
