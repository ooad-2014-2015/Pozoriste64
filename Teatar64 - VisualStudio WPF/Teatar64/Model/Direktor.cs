using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64.Model
{
    public class Direktor
    {
        public DateTime DatumRodjenja { get; set; }
        public DateTime getDatumRodjenja() { return DatumRodjenja; }
        public String promijeniSifru(Uposlenik u)
        {
            String s = "sifra"; //privremeno
            return s;
        }
    }
}
