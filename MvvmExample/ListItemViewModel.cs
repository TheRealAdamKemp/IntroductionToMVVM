using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmExample
{
    public class ListItemViewModel : NotifyPropertyChanged
    {
        private readonly ListViewModel _listViewModel;

        public ListItemViewModel(ListViewModel listViewModel)
        {
            if (listViewModel == null)
            {
                throw new ArgumentNullException("listViewModel");
            }
            _listViewModel = listViewModel;
        }

        public string Title { get; set; }

        private ICommand _deleteItemCommand;
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_deleteItemCommand == null)
                {
                    _deleteItemCommand = new Command(() => _listViewModel.Items.Remove(this));
                }

                return _deleteItemCommand;
            }
        }
    }
}

