using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64.Model
{
    public class Prostorija : INotifyPropertyChanged
    {
        public int brojMjesta { get; set; }
        public String nazivProstorije { get; set; }
        public int DajBrojMjesta() { return brojMjesta; }
        public Prostorija(int broj, string naziv)
        {
            brojMjesta = broj;
            nazivProstorije = naziv;
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
