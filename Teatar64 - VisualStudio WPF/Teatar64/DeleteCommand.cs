using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Teatar64.Model;
using Teatar64.ViewModel;

namespace Teatar64
{
    class DeleteCommand : ICommand
    {
        private readonly IService _service;
        private readonly Func<bool> _canExecute;
        private readonly Action<Prostorija> _deleted;

        public DeleteCommand(IService service, Func<bool> canExecute,
                                  Action<Prostorija> deleted)
        {
            _service = service;
            _canExecute = canExecute;
            _deleted = deleted;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                var prostorija = parameter as Prostorija;
                if (prostorija != null)
                {
                    var result = MessageBox.Show(
                      "Da li sigurno zelite obrisati prostoriju?",
                      "Confirm Delete", MessageBoxButton.OKCancel);

                    if (result.Equals(MessageBoxResult.OK))
                    {
                        _service.ObrisiProstoriju(prostorija);
                        if (_deleted != null)
                        {
                            _deleted(prostorija);
                        }
                    }
                }
            }
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
