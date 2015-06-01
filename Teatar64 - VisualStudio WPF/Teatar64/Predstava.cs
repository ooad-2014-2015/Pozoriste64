using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64
{
    //public enum VrstaPredstave { "Djecija", "Musical" };

    class VrstaPredstave { } //samo zbog errora, treba biti enum

    class Predstava
    {
        public VrstaPredstave tip { get; set; }
        public Prostorija sala { get; set; }
        public Uposlenik reziser { get; set; }
        public List<Uposlenik> glumci { get; set; }
        public void DodajGlumca(Uposlenik u)
        {
            glumci.Add(u);
        }
    }
}
