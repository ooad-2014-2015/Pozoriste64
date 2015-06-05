using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teatar64.Baza;
using Teatar64.Model;


namespace Teatar64.ViewModel
{
    class ProstorijaViewModel
    {        
        public static void UnesiProstoriju(Prostorija p)
        {
            KameniTeatar64 baza = new KameniTeatar64();
            baza.UpisiProstoriju(p);
        }
    }
}
