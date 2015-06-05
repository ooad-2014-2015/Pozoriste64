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
using Teatar64.Model;
using Teatar64.Baza;

namespace Teatar64.View
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class FormaPredstave : Window
    {
        FormaProducent parent { get; set; }
        public List<String> UcitajCombo
        {
            get
            {
                Baza.KameniTeatar64 baza = new Baza.KameniTeatar64();
                return baza.UcitajVrstePredstave();
            }
        }
        public List<String> UcitajSale
        {
            get
            {
                Baza.KameniTeatar64 baza = new Baza.KameniTeatar64();
                return baza.UcitajSale();
            }
        }
        public List<String> UcitajTermine
        {
            get
            {
                Baza.KameniTeatar64 baza = new Baza.KameniTeatar64();
                return baza.UcitajTermine();
            }
        }
        public FormaPredstave(FormaProducent p)
        {
            parent = p;
            InitializeComponent();
            VrstaComboBox.ItemsSource = UcitajCombo;
            ProstorijaComboBox.ItemsSource = UcitajSale;
            TerminiComboBox.ItemsSource = UcitajTermine;
        }
        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            KameniTeatar64 baza = new KameniTeatar64();
            if (!baza.ProvjeriDaLiJeSlobodna(ProstorijaComboBox.SelectedValue.ToString(), TerminiComboBox.SelectedValue.ToString()))
            {
                MessageBox.Show("Sala nije slobodna u odabranom terminu.");
                return;
            }
            baza.UpisiPredstavu(VrstaComboBox.SelectedValue.ToString(), ReziserTextBox.Text, ProducentTextBox.Text, NazivtextBox.Text, ProstorijaComboBox.SelectedValue.ToString(), Datum_premijere.SelectedDate.Value, TerminiComboBox.SelectedValue.ToString());
        }

        private void ProstorijaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TerminiComboBox.SelectedIndex == -1) return;
           /* KameniTeatar64 baza = new KameniTeatar64();
            if (!baza.ProvjeriDaLiJeSlobodna(ProstorijaComboBox.SelectedValue.ToString(), TerminiComboBox.SelectedValue.ToString()))
            {
                MessageBox.Show("Sala nije slobodna u odabranom terminu.");
            } */
        }

        private void TerminiComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProstorijaComboBox.SelectedIndex == -1) return;
            /*KameniTeatar64 baza = new KameniTeatar64();
            if (!baza.ProvjeriDaLiJeSlobodna(ProstorijaComboBox.SelectedValue.ToString(), TerminiComboBox.SelectedValue.ToString()))
            {
                MessageBox.Show("Sala nije slobodna u odabranom terminu.");
            } */
        }
    }
}