using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Teatar64.Model;
using Teatar64.View;

namespace Teatar64
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
         int LogIn(String korisnickoIme, String sifra);
         void Connect();
         void Disconnect();
         List<String> UcitajSale();
         List<String> UcitajTermine();
         List<String> UcitajVrstePredstave();
         List<Predstava> UcitajPredstave();
         List<Uposlenik> UcitajUposlenike(String ime);
         void UpdatePredstavu(String naziv, String datum, int kolicina);
         bool ProvjeriDaLiJeSlobodna(String prostorija, String termin);
         int UpisiPredstavu(String vrsta, String reziser, String producent, String naziv, String prostorija, DateTime datum, String termin);
         int UpisiProstoriju(Prostorija p);
         int NadjiUposlenikID(String imeprezime);
         int NadjiPredstavaTerminID(String naziv, String datum);
         int NadjiProstorijaID(String naziv);
         int NadjiProstorijaKapacitet(String naziv);
         int NadjiVrstaID(String naziv);
         int NadjiTerminID(String vrijeme);
         void ObrisiProstoriju(Prostorija p);
    }
}
