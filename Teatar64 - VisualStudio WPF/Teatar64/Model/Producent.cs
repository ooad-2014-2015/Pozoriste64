using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64.Model
{
    class Producent : Uposlenik
    {
        public Producent(String ime, String p, String datRodj, String datUposl) : base(ime, p, datRodj, datUposl) { }
        public void DodajPredstavu() { } //spojiti sa ViewModel-om
        public void ObrisiPredstavu() { }
    }
}
