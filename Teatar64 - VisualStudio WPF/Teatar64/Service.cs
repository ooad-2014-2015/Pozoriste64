using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Data;
using Teatar64.Model;

namespace Teatar64
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in both code and config file together.
    public class Service : IService
    {
        MySqlConnection dataConnection { get; set; }
        String username { get; set; }
        String password { get; set; }
        String dbName { get; set; }

        public void Connect()
        {
            username = "root";
            password = "";
            dbName = "ooadpozoriste";
            string connectionString = "server=localhost;user=" + username + ";pwd=" + password + ";database=" + dbName;

            dataConnection = new MySqlConnection(connectionString);
            dataConnection.Open();
        }
        public void Disconnect()
        {
            dataConnection.Close();
        }
        public int LogIn(String korisnickoIme, String sifra)
        {
            try
            {
                Connect();

                MySqlCommand provjera = new MySqlCommand(
                    "SELECT * FROM osoblje WHERE sifra='" + sifra + "';", dataConnection);
                MySqlDataReader reader = provjera.ExecuteReader();
                reader.Read();

                String korisnicno = reader.GetString("ime") + reader.GetString("prezime");

                if (korisnicno.ToLower() == korisnickoIme) return reader.GetInt32("ovlastenje");

                reader.Close();
                Disconnect();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
            return -1;
        }
        public void ObrisiProstoriju(Prostorija p)
        {
 
        }
        public List<String> UcitajSale()
        {
            List<String> lista = new List<String>();
            try
            {
                Connect();
                MySqlCommand ucitaj = new MySqlCommand("SELECT naziv FROM prostorije", dataConnection);
                MySqlDataReader reader = ucitaj.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(reader.GetString("naziv"));
                }
                reader.Close();

                Disconnect();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return lista;
        }

        public List<String> UcitajTermine()
        {
            List<String> lista = new List<String>();
            try
            {
                Connect();
                MySqlCommand ucitaj = new MySqlCommand("SELECT vrijeme FROM termini", dataConnection);
                MySqlDataReader reader = ucitaj.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(reader.GetString("vrijeme"));
                }
                reader.Close();

                Disconnect();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return lista;
        }

        public List<String> UcitajVrstePredstave()
        {
            List<String> lista = new List<String>();
            try
            {
                Connect();

                MySqlCommand ucitaj = new MySqlCommand("SELECT naziv FROM vrstepredstava;", dataConnection);

                MySqlDataReader reader = ucitaj.ExecuteReader();
                while (reader.Read())
                {
                    String s = (string)((IDataRecord)reader)[0];
                    lista.Add(s);
                }

                reader.Close();
                Disconnect();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return lista;
        }

        public List<Predstava> UcitajPredstave()
        {
            List<Predstava> lista = new List<Predstava>();
            try
            {
                Connect();

                MySqlCommand ucitaj = new MySqlCommand(
                    "SELECT pred.naziv, vp.naziv,p.naziv, pt.br_sl, t.vrijeme, o.ime, pt.datum FROM osoblje o, vrstepredstava vp, predstavespisak pred, predstavetermini pt, termini t, prostorije p WHERE pt.predstava_id=pred.id AND pt.termin_id=t.id AND pred.prostorija_id=p.id AND vp.id = pred.vrsta_id AND pred.producent_id = o.id AND pt.datum >= CURDATE() ORDER BY pt.datum;", dataConnection);
                MySqlDataReader reader = ucitaj.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Predstava(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToDateTime(reader[6].ToString())));

                }

                reader.Close();
                Disconnect();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return lista;
        }
        public List<Uposlenik> UcitajUposlenike(String ime)
        {
            List<Uposlenik> lista = new List<Uposlenik>();
            try
            {
                Connect();

                MySqlCommand ucitaj;
                if (ime == "") ucitaj = new MySqlCommand("SELECT ime, prezime, datumRodj, datumUposlenja, plata, sifra FROM osoblje;", dataConnection);

                else ucitaj = new MySqlCommand("SELECT ime, prezime, datumRodj, datumUposlenja, plata, sifra FROM osoblje WHERE ime LIKE '%" + ime + "%' OR prezime LIKE '%" + ime + "%';", dataConnection);
                MySqlDataReader reader = ucitaj.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Uposlenik(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),Convert.ToDouble(Convert.ToDecimal( reader[4].ToString())), reader[5].ToString()));

                }

                reader.Close();
                Disconnect();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return lista;
        }

        public void UpdatePredstavu(String naziv, String datum, int kolicina)
        {
            int id = NadjiPredstavaTerminID(naziv, datum);
            if (id == -1)
            {
                MessageBox.Show("Nije pronasao termin.");
                return;
            }
            try
            {
                Connect();
                MySqlCommand update = new MySqlCommand(
                    "UPDATE predstavetermini SET br_sl = br_sl - " + kolicina + " WHERE id = " + id + ";", dataConnection);
                update.ExecuteNonQuery();

                Disconnect();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool ProvjeriDaLiJeSlobodna(String prostorija, String termin)
        {
            try
            {
                Connect();

                MySqlCommand provjera = new MySqlCommand(
                    "SELECT t.vrijeme FROM predstavespisak pred, predstavetermini pt, termini t, prostorije p WHERE pt.predstava_id=pred.id AND pt.termin_id=t.id AND pred.prostorija_id=p.id AND p.naziv='" + prostorija + "' AND t.vrijeme='" + termin + "';", dataConnection);
                MySqlDataReader reader = provjera.ExecuteReader();

                if (reader.Read())
                {
                    if (reader[0] != DBNull.Value)
                    {
                        reader.Close();
                        return false;
                    }
                }
                reader.Close();

                Disconnect();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public int UpisiPredstavu(String vrsta, String reziser, String producent, String naziv, String prostorija, DateTime datum, String termin)
        {
            int broj = NadjiProstorijaKapacitet(prostorija);
            int v = NadjiVrstaID(vrsta);
            int r = NadjiUposlenikID(reziser);
            int p = NadjiUposlenikID(producent);
            int pr = NadjiProstorijaID(prostorija);
            int t = NadjiTerminID(termin);

            if (broj == -1 || v == -1 || r == -1 || p == -1 || pr == -1 || t == -1)
            {
                MessageBox.Show("Upisani podaci nisu u bazi podataka.");
                if (v == -1) MessageBox.Show("Vrsta greska!");
                if (broj == -1) MessageBox.Show("Broj greska!");
                if (r == -1) MessageBox.Show("Reziser nije prepoznat!");
                if (p == -1) MessageBox.Show("Producent nije prepoznat!");
                if (pr == -1) MessageBox.Show("Prostorija greska!");
                if (t == -1) MessageBox.Show("Termin greska!");
                return -1;
            }

            int id = -1;
            try
            {
                Connect();

                MySqlCommand upis = new MySqlCommand(
                    "INSERT INTO predstavespisak (vrsta_id, producent_id, naziv, prostorija_id, reziser_id) VALUES (" + v + "," + p + ", '" + naziv + "', " + pr + ", " + r + ");", dataConnection);
                upis.ExecuteNonQuery();

                upis = new MySqlCommand(
                    "SELECT id from predstavespisak WHERE naziv= '" + naziv + "';", dataConnection);
                MySqlDataReader reader = upis.ExecuteReader();

                if (reader.Read()) id = reader.GetInt32("id");

                reader.Close();


                for (int i = 0; i < 10; i++)
                {
                    upis = new MySqlCommand(
                        "INSERT INTO predstavetermini (predstava_id, datum, termin_id, br_sl) VALUES (" + id + ", '" + datum.Date.Year.ToString() + "-" + datum.Date.Month.ToString() + "-" + datum.Date.Day.ToString() + "', " + t + ", " + broj + ");", dataConnection);
                    upis.ExecuteNonQuery();
                    datum = datum.AddDays(1);
                }

                Disconnect();
                MessageBox.Show("Predstava uspjesno dodana.");

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
            return -1;
        }
        public int UpisiProstoriju(Prostorija p)
        {
            try
            {
                Connect();
                int id = 0;
                if (p is Sala)
                {
                    MySqlCommand upis = new MySqlCommand(
                    "INSERT INTO prostorije (tip, broj_mjesta, naziv) VALUES ( 'S', " + p.brojMjesta +
                    ", '" + p.nazivProstorije.ToString() + "');", dataConnection);
                    upis.ExecuteNonQuery();

                    upis = new MySqlCommand(
                        "SELECT id FROM prostorije WHERE naziv = '" + p.nazivProstorije + "';", dataConnection);
                    MySqlDataReader reader = upis.ExecuteReader();
                    if (reader.Read()) id = reader.GetInt32("id");

                    reader.Close();

                    Disconnect();
                }
                if (p is Teatar)
                {
                    MySqlCommand upis = new MySqlCommand(
                    "INSERT INTO prostorije (tip, broj_mjesta, naziv, velicina) VALUES ('T', " + p.brojMjesta.ToString() +
                    ", '" + p.nazivProstorije + "', " + (p as Teatar).velicinaPozornice + ");", dataConnection);
                    upis.ExecuteNonQuery();

                    upis = new MySqlCommand(
                        "SELECT id FROM prostorije WHERE naziv = '" + p.nazivProstorije + "';", dataConnection);
                    MySqlDataReader reader = upis.ExecuteReader();

                    if (reader.Read()) id = reader.GetInt32("id");

                    reader.Close();

                    Disconnect();
                }
                MessageBox.Show("Uspjesno ste dodali prostoriju.");
                return id;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Konekcija s bazom nije uspjela.\n" + e.Message);
            }
            return 0;
        }
        public int NadjiUposlenikID(String imeprezime)
        {
            int id = -1, space = imeprezime.IndexOf(" ");
            String ime = imeprezime.Substring(0, space + 1), prezime = imeprezime.Substring(space + 1, imeprezime.Length - (space + 1));
            try
            {
                Connect();

                MySqlCommand citaj = new MySqlCommand(
                    "SELECT id FROM osoblje WHERE ime = '" + ime + "' AND prezime= '" + prezime + "';", dataConnection);
                MySqlDataReader reader = citaj.ExecuteReader();

                if (reader.Read()) id = reader.GetInt32("id");

                reader.Close();
                Disconnect();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return id;
        }
        public int NadjiPredstavaTerminID(String naziv, String datum)
        {
            int id = -1;
            try
            {
                Connect();

                MySqlCommand citaj = new MySqlCommand(
                    "SELECT pt.id FROM predstavetermini pt, predstavespisak pred WHERE pt.predstava_id = pred.id AND pred.naziv= '" + naziv + "' AND pt.datum='" + datum + "';", dataConnection);
                MySqlDataReader reader = citaj.ExecuteReader();

                if (reader.Read()) id = reader.GetInt32("id");

                reader.Close();
                Disconnect();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return id;
        }
        public int NadjiProstorijaID(String naziv)
        {
            int id = -1;
            try
            {
                Connect();

                MySqlCommand citaj = new MySqlCommand(
                    "SELECT id FROM prostorije WHERE naziv = '" + naziv + "';", dataConnection);
                MySqlDataReader reader = citaj.ExecuteReader();

                if (reader.Read()) id = reader.GetInt32("id");

                reader.Close();
                Disconnect();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return id;
        }
        public int NadjiProstorijaKapacitet(String naziv)
        {
            int br = -1;
            try
            {
                Connect();

                MySqlCommand citaj = new MySqlCommand(
                    "SELECT broj_mjesta FROM prostorije WHERE naziv = '" + naziv + "';", dataConnection);
                MySqlDataReader reader = citaj.ExecuteReader();

                if (reader.Read()) br = reader.GetInt32("broj_mjesta");

                reader.Close();
                Disconnect();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return br;
        }
        public int NadjiVrstaID(String naziv)
        {
            int id = -1;
            try
            {
                Connect();

                MySqlCommand citaj = new MySqlCommand(
                    "SELECT id FROM vrstepredstava WHERE naziv = '" + naziv + "';", dataConnection);
                MySqlDataReader reader = citaj.ExecuteReader();

                if (reader.Read()) id = reader.GetInt32("id");

                reader.Close();
                Disconnect();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return id;
        }
        public int NadjiTerminID(String vrijeme)
        {
            int id = -1;
            try
            {
                Connect();

                MySqlCommand citaj = new MySqlCommand(
                    "SELECT id FROM termini WHERE vrijeme = '" + vrijeme + "';", dataConnection);
                MySqlDataReader reader = citaj.ExecuteReader();

                if (reader.Read()) id = reader.GetInt32("id");

                reader.Close();
                Disconnect();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return id;
        }
    }
}
