using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Teatar64.Baza;
using System.Collections;
using Teatar64.Model;

namespace Teatar64
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Blagajna : Window
    {
       public MainWindow login { get; set; }
       private List<Predstava> _gridsource;
        public List<Predstava> GridSource
        {
            get
            {
                KameniTeatar64 baza = new KameniTeatar64();
                _gridsource = baza.UcitajPredstave();
                return _gridsource;
            }
            set
            {
                _gridsource = value;
            }
        }
        public Blagajna(MainWindow reg)
        {
            login = reg;
            InitializeComponent();
            UcitajPredstave();
        }
        private void UpdateGridSource()
        {
            KameniTeatar64 baza = new KameniTeatar64();
            GridSource = baza.UcitajPredstave();
        }

        private void UcitajPredstave()
        {
            PredstaveDataGrid.ItemsSource = GridSource;
        }

        private void BlagajnaForma_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            login.OcistiPodatke();
            login.Show();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private String DajNaziv()
        {
            return GridSource.ElementAt(PredstaveDataGrid.SelectedIndex).Naziv;
        }
        private String DajDatum()
        {
            String datum = GridSource.ElementAt(PredstaveDataGrid.SelectedIndex).Datum.Year.ToString() + "-" + GridSource.ElementAt(PredstaveDataGrid.SelectedIndex).Datum.Month.ToString() + "-" + GridSource.ElementAt(PredstaveDataGrid.SelectedIndex).Datum.Day.ToString();
            return datum;
        }

        private void PotvrdiKupovinuButton_Click(object sender, RoutedEventArgs e)
        {
            if (PredstaveDataGrid.SelectedIndex == -1 || KolicinaTextBox.Text == "")
            {
                MessageBox.Show("Niste unijeli podatke.");
                return;
            }
            KameniTeatar64 baza = new KameniTeatar64();
            baza.UpdatePredstavu(DajNaziv() , DajDatum(), Convert.ToInt32(KolicinaTextBox.Text));
            UpdateGridSource();
            UcitajPredstave();
            OcistiUnos();
        }
        private void OcistiUnos()
        {
            PredstaveDataGrid.SelectedIndex = -1;
            KolicinaTextBox.Text = "";
        }

        private void PonistiKupovinuButton_Click(object sender, RoutedEventArgs e)
        {
            OcistiUnos();
        }

        private void KakoKoristitiButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1. Selektujte predstavu\n"+
                "2. Unesite kolicinu (za povrat unesite negativnu vrijednost)\n"+
                "3. Kliknite dugme Potvrdi");
        }
    }
}
