using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64.Model
{
    public class Producent : Uposlenik
    {
        public Producent(String ime, String p, String datRodj, String datUposl, Double pl, String sifra) : base(ime, p, datRodj, datUposl, pl, sifra) { }
        public void DodajPredstavu() { } //spojiti sa ViewModel-om
        public void ObrisiPredstavu() { }
    }
}
