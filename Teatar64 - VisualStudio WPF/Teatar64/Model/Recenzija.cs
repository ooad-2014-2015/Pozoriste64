using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64.Model
{
    public class Recenzija
    {
        public String Naziv { get; set; }
        public String Komentar { get; set; }
        public String Prijedlog { get; set; }
        public String Ocjena { get; set; }
        public Recenzija(String naz, String kom, String pr, String ocj)
        {
            Naziv = naz;
            Komentar = kom;
            Prijedlog = pr;
            Ocjena = ocj;
        }
    }
}
