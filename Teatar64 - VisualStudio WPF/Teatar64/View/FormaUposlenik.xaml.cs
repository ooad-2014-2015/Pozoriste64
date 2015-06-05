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

namespace Teatar64.View
{
    /// <summary>
    /// Interaction logic for FormaUposlenik.xaml
    /// </summary>
    public partial class FormaUposlenik : Window
    {
        public FormaUposlenik()
        {
            InitializeComponent();
            UcitajRadnePozicije();
        }
        public void UcitajRadnePozicije()
        {
            KameniTeatar64 baza = new KameniTeatar64();
            RadnoMjestoComboBox.ItemsSource = baza.UcitajRadnePozicije();
        }
        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            String datum = DatumRodjenjaPicker.SelectedDate.Value.Year.ToString()+"-"+DatumRodjenjaPicker.SelectedDate.Value.Month.ToString()+"-"+DatumRodjenjaPicker.SelectedDate.Value.Day.ToString();
            MessageBox.Show(datum);
            KameniTeatar64 baza = new KameniTeatar64();
            baza.UpisiUposlenika(ImeTextBox.Text, PrezimeTextBox.Text, datum, DateTime.Today.Year.ToString()+"-"+DateTime.Today.Month.ToString()+"-"+DateTime.Today.Day.ToString(), RadnoMjestoComboBox.SelectedValue.ToString(), Convert.ToDouble(Convert.ToDecimal(PlataTextBox.Text)), (ImeTextBox.Text[0].ToString() + PrezimeTextBox.Text[0].ToString() + DatumRodjenjaPicker.SelectedDate.Value.Year.ToString()));
            OcistiSve();
        }
        public void OcistiSve()
        {
            ImeTextBox.Text = "";
            PrezimeTextBox.Text = "";
            RadnoMjestoComboBox.SelectedIndex = -1;
            PlataTextBox.Text = "";
        }
        private void PonistiButton_Click(object sender, RoutedEventArgs e)
        {
            OcistiSve();
        }
    }
}
