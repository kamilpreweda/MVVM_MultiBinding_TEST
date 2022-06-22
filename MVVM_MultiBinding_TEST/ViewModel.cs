using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_MultiBinding_TEST;

namespace MVVM_MultiBinding_TEST
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ICommand MyCommand { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private int _number1;
        public int Number1
        {
            get { return _number1; }
            set { _number1 = value; OnPropertyChanged("Number1"); }
        }

        private int _number2;
        public int Number2
        {
            get { return _number2; }
            set { _number2 = value; OnPropertyChanged("Number2"); }
        }

        private int numberSum;
        public int NumberSum
        {
            get { return numberSum; }
            set { numberSum = value; OnPropertyChanged("NumberSum"); }
        }

        public ViewModel()
        {
            MyCommand = new RelayCommand(execute, canexecute);
        }

        private bool canexecute(object parameter)
        {
            if (Number1 != null || Number2 != null){
                return true;
            } else { return false; }
        }

        private void execute(object parameter)
        {

        }
    }

}
