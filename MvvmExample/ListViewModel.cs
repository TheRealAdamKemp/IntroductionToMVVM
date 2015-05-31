using System.Collections.ObjectModel;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace MvvmExample
{
    [ImplementPropertyChanged]
    public class ListViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<ListItemViewModel> Items { get; } = new ObservableCollection<ListItemViewModel>();

        private ICommand _addItemCommand;
        public ICommand AddItemCommand
        {
            get
            {
                if (_addItemCommand == null)
                {
                    _addItemCommand = new Command(() => Items.Add(new ListItemViewModel(this) { Title =  Items.Count.ToString() }));
                }

                return _addItemCommand;
            }
        }
    }
}


