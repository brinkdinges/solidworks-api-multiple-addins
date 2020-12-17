using System.ComponentModel;

namespace CADBooster.Detached.Addin.Windows.TaskPane
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
