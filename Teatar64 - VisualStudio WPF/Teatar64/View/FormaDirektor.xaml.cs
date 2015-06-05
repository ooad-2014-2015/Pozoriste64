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
    /// Interaction logic for FormaDirektor.xaml
    /// </summary>
    public partial class FormaDirektor : Window
    {
        MainWindow login { get; set; }
        List<Uposlenik> PretragaSource
        {
            get
            {
                KameniTeatar64 baza = new KameniTeatar64();
                return baza.UcitajUposlenike(pretragaTextBox.Text);
            }
        }
        public FormaDirektor(MainWindow l)
        {
            login = l;
            InitializeComponent();
            UposleniciGridView.ItemsSource = PretragaSource;
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

        private void TraziButton_Click(object sender, RoutedEventArgs e)
        {
            UposleniciGridView.ItemsSource = PretragaSource;
        }
    }
}
