using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.Core;

internal class ObservableObject : INotifyPropertyChanged
{
    //se implementa el evento
    public event PropertyChangedEventHandler? PropertyChanged;

    //cremos el manejador
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

