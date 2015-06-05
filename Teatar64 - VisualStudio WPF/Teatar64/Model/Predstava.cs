using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teatar64.Baza;

namespace Teatar64.Model
{


    public class Predstava
    {

        public String Naziv { get; set; }
        public String Tip { get; set; }
        public String Sala { get; set; }
        public String BrMjesta { get; set; }
        public String Reziser { get; set; }
        public String Vrijeme { get; set; }
        public DateTime Datum { get; set; }
        //public List<Uposlenik> glumci { get; set; }
        public static List<String> VrstaPredstave;

        private void UcitajVrste()
        {
            Baza.KameniTeatar64 baza = new Baza.KameniTeatar64();
            VrstaPredstave = baza.UcitajVrstePredstave();
        }
        
        public Predstava(String n, String vrsta, String broj,  String s, String u, String time, DateTime dat)
        {

            Naziv = n;
            Tip = vrsta;
            Sala = s;
            BrMjesta = broj;
            Reziser = u;
            Vrijeme = time;
            Datum = dat;
        }
    }
}
