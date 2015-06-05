using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teatar64.Baza;
using Teatar64.Model;


//Nije implementiran ViewModel odnosno nije koristen
//Rjesenje je uradjeno na komplikovaniji (cinilo se pocetniku kao dobar izbor)
//i nimalo lijep nacin
//Ovako bi to trebalo otprilike da izgleda

namespace Teatar64.ViewModel
{
    class ProstorijaViewModel : INotifyPropertyChanged
    {
        public ProstorijaViewModel()
        {
            Prostorije = new ObservableCollection<String>();
            Service = new Service();

            _NapuniProstorije(Service.UcitajSale());

            Delete = new DeleteCommand(
                Service, 
                ()=>CanDelete,
                contact =>
                    {
                        CurrentProstorija = null;
                        _NapuniProstorije(Service.UcitajSale());
                    });
        }

        private void _NapuniProstorije(IEnumerable<String> contacts)
        {
            Prostorije.Clear();
            foreach(var contact in contacts)
            {
                Prostorije.Add(contact);
            }
        }

        public IService Service { get; set; }

        public bool CanDelete
        {
            get { return _currentProstorija != null; }
        }

        public ObservableCollection<String> Prostorije { get; set; }

        public DeleteCommand Delete { get; set; }

        private Prostorija _currentProstorija;

        public Prostorija CurrentProstorija
        {
            get { return _currentProstorija; }
            set
            {
                _currentProstorija = value;
                RaisePropertyChanged("CurrentContact");
                RaisePropertyChanged("CanDelete");
                Delete.RaiseCanExecuteChanged();
            }
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public static void UnesiProstoriju(Prostorija p)
        {
            KameniTeatar64 baza = new KameniTeatar64();
            baza.UpisiProstoriju(p);
        } 
    }
}
