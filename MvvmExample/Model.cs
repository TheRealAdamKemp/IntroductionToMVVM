using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmExample
{
    public class Model : INotifyPropertyChanged
    {
        private readonly double _defaultValue;

        public Model(double defaultValue)
        {
            _defaultValue = defaultValue;
            Reset();
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName");
            }

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public void Reset()
        {
            Value = _defaultValue;
        }

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                    UpdateOutOfRange();
                }
            }
        }

        private void UpdateOutOfRange()
        {
            IsOutOfRange = (Value < 0 || Value > 10);
        }

        private bool _isOutOfRange;
        public bool IsOutOfRange
        {
            get { return _isOutOfRange; }
            private set
            {
                if (_isOutOfRange != value)
                {
                    _isOutOfRange = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

