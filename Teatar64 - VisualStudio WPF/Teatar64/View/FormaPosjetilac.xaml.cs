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
using Teatar64.Baza;
using Teatar64.Model;

namespace Teatar64.View
{
    /// <summary>
    /// Interaction logic for FormaPosjetilac.xaml
    /// </summary>
    public partial class FormaPosjetilac : Window
    {
        public MainWindow login { get; set; }
        private List<Predstava> _predstavasource;
        private List<String> _recenzijesource;
        public List<Predstava> PredstavaSource
        {
            get
            {
                KameniTeatar64 baza = new KameniTeatar64();
                _predstavasource = baza.UcitajPredstave();
                return _predstavasource;
            }
            set
            {
                _predstavasource = value;
            }
        }
        public List<String> RecenzijeSource
        {
            get
            {
                KameniTeatar64 baza = new KameniTeatar64();
                _recenzijesource = baza.UcitajSpisakPredstava();
                return _recenzijesource;
            }
            set
            {
                _recenzijesource = value;
            }
        }
        public FormaPosjetilac(MainWindow lg)
        {
            login = lg;
            InitializeComponent();
            UcitajPredstave();
            UcitajRecenzijeSource();
        }
        public void UcitajPredstave()
        {
            PredstaveDataGrid.ItemsSource = PredstavaSource;
        }
        public void UcitajRecenzijeSource()
        {
            PredstaveComboBox.ItemsSource = RecenzijeSource;
        }
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            login.OcistiPodatke();
            login.Show();
        }
        public void OcisitSve()
        {
            PredstaveComboBox.SelectedIndex = -1;
            KomentarTextBox.Text = "";
            PrijedlogTextBox.Text = "";
            JedanRadioButton.IsChecked = false;
            DvaRadioButton.IsChecked = false;
            TriRadioButton.IsChecked = false;
            CetiriRadioButton.IsChecked = false;
            PetRadioButton.IsChecked = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OcisitSve();
        }

        private void SacuvajButton_Click(object sender, RoutedEventArgs e)
        {
            int ocjena = 5;
            if(JedanRadioButton.IsChecked == true) ocjena =1;
            if (DvaRadioButton.IsChecked == true) ocjena = 2;
            if (TriRadioButton.IsChecked == true) ocjena = 3;
            if (CetiriRadioButton.IsChecked == true) ocjena = 4;
            if (PetRadioButton.IsChecked == true) ocjena = 5;
            KameniTeatar64 baza = new KameniTeatar64();
            baza.UpisiRecenziju(PredstaveComboBox.SelectedValue.ToString(), KomentarTextBox.Text, PrijedlogTextBox.Text, ocjena);
            OcisitSve();
        }
    }
}
