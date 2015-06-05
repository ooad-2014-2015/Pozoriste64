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
using System.Threading;

namespace Teatar64.View
{
    /// <summary>
    /// Interaction logic for FormaDirektor.xaml
    /// </summary>
    public partial class FormaDirektor : Window
    {
        public MainWindow login { get; set; }
        private List<Uposlenik> _pretragasource;
        public List<Uposlenik> PretragaSource
        {
            get
            {
                 KameniTeatar64 baza = new KameniTeatar64();
                 _pretragasource = baza.UcitajUposlenike(pretragaTextBox.Text);
                return _pretragasource;
            }
            set
            {
                _pretragasource = value;
            }
        }
        public List<Uposlenik> DajPretragaSource()
        {
            this.Dispatcher.BeginInvoke(new Action(()=>{
            KameniTeatar64 baza = new KameniTeatar64();
                 _pretragasource = baza.UcitajUposlenike(pretragaTextBox.Text); }));
            return _pretragasource;
        }
        public FormaDirektor(MainWindow l)
        {
            login = l;
            InitializeComponent();
            UcitajUposlenike();
        }
        private void UpdatePretragaSource()
        {
            KameniTeatar64 baza = new KameniTeatar64();
            PretragaSource = baza.UcitajUposlenike(pretragaTextBox.Text);
        }
        public void UpdatePretragaSourceThread()
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                KameniTeatar64 baza = new KameniTeatar64();
                PretragaSource = baza.UcitajUposlenike(pretragaTextBox.Text);
            }));
            //PretragaSource = baza.UcitajUposlenike(tekst);
        }
        private void UcitajUposlenike()
        {
            UposleniciGridView.ItemsSource = PretragaSource;
        }
        public void UcitajUposlenikeThread()
        {
            this.Dispatcher.BeginInvoke(new Action(()=>{UposleniciGridView.ItemsSource = DajPretragaSource();}));
        }
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            login.OcistiPodatke();
            login.Show();
        }

        private void NovaProstorijaButton_Click(object sender, RoutedEventArgs e)
        {
            FormaProstorija prozor = new FormaProstorija(this);
            prozor.Show();
        }

        private void pretragaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            Thread nit = new Thread(new ThreadStart(() =>
            {
                UpdatePretragaSourceThread();
            UcitajUposlenikeThread();
            }));
            nit.IsBackground = false;
            nit.Start();
        }

        private void NoviUposlenikButton_Click(object sender, RoutedEventArgs e)
        {
            FormaUposlenik prozor = new FormaUposlenik();
            prozor.Show();
        }
    }
}
