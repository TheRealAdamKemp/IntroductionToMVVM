using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace MvvmExample
{
    [ImplementPropertyChanged]
    public class ViewModel : NotifyPropertyChanged
    {
        private readonly Model _model;
        public ViewModel(Model model)
        {
            _model = model;
        }

        [AlsoNotifyFor("IsOutOfRange", "BackgroundColor")]
        public double Value
        {
            get { return _model.Value; }
            set { _model.Value = value; }
        }

        public bool IsOutOfRange { get { return _model.IsOutOfRange; } }

        public Color BackgroundColor
        {
            get { return _model.IsOutOfRange ? Color.Red : Color.White; }
        }

        private ICommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                {
                    _resetCommand = new Command(() =>
                        {
                            _model.Reset();
                            OnPropertyChanged("Value");
                            OnPropertyChanged("IsOutOfRange");
                            OnPropertyChanged("BackgroundColor");
                        });
                }

                return _resetCommand;
            }
        }
    }
}

