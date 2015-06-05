using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Teatar64.View;
using Teatar64.Baza;

namespace Teatar64
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void OcistiPodatke()
        {
            korisnickoImeTextBox.Text = "";
            lozinkaTextBox.Password = "";
        }

        private void ponistiButton_Click(object sender, RoutedEventArgs e)
        {
            OcistiPodatke();
        }

        private void registrujButton_Click(object sender, RoutedEventArgs e)
        {
            KameniTeatar64 baza = new KameniTeatar64();

            if(korisnickoImeTextBox.Text == "1" && lozinkaTextBox.Password == "1")
            {
                KreirajBazu();
            }

            int id = baza.LogIn(korisnickoImeTextBox.Text, lozinkaTextBox.Password);
            if (id == 1)
            {
                FormaDirektor prozor = new FormaDirektor(this);
                prozor.Show();
                this.OcistiPodatke();
                this.Hide();
            }
            else if (id == 3)
            {
                FormaProducent prozor = new FormaProducent(this);
                prozor.Show();
                this.OcistiPodatke();
                this.Hide();
            }
            else if (id == 4)
            {
                Blagajna prozor = new Blagajna(this);
                prozor.Show();
                this.OcistiPodatke();
                this.Hide();
            }
            else if(id == -1)
            {
                MessageBox.Show("Korisnično ime ili šifra nije tačna.");
                this.OcistiPodatke();
            }
        }
        public void KreirajBazu()
        {
            return;
        }
    }
}
