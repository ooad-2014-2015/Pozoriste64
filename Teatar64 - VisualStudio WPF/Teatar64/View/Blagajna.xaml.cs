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
        MainWindow login { get; set; }
        List<Predstava> GridSource
        {
            get
            {
                KameniTeatar64 baza = new KameniTeatar64();
                return baza.UcitajPredstave();
            }
        }
        public Blagajna(MainWindow reg)
        {
            login = reg;
            InitializeComponent();
            UcitajPredstave();

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

        private void PotvrdiKupovinuButton_Click(object sender, RoutedEventArgs e)
        {
            if (PredstaveDataGrid.SelectedIndex == -1 || KolicinaTextBox.Text == "")
            {
                MessageBox.Show("Niste unijeli podatke.");
                return;
            }
            KameniTeatar64 baza = new KameniTeatar64();
            baza.UpdatePredstavu(PredstaveDataGrid.SelectedCells[0].ToString() , PredstaveDataGrid.SelectedCells[0].Item.ToString(), Convert.ToInt32(KolicinaTextBox.Text));
            UcitajPredstave();
        }

        private void PonistiKupovinuButton_Click(object sender, RoutedEventArgs e)
        {
            PredstaveDataGrid.SelectedIndex = -1;
            KolicinaTextBox.Text = "";
        }
    }
}
