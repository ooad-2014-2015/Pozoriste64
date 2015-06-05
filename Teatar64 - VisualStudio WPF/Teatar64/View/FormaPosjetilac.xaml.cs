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
        public FormaPosjetilac(MainWindow lg)
        {
            login = lg;
            InitializeComponent();
            UcitajPredstave();
        }
        public void UcitajPredstave()
        {
            PredstaveDataGrid.ItemsSource = PredstavaSource;
        }
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            login.OcistiPodatke();
            login.Show();
        }
    }
}
