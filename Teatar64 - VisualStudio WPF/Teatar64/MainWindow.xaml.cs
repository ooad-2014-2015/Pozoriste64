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
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void ponistiButton_Click(object sender, RoutedEventArgs e)
        {
            korisnickoImeTextBox.Text = "";
            lozinkaTextBox.Password = "";
        }

        private void registrujButton_Click(object sender, RoutedEventArgs e)
        {
            if (korisnickoImeTextBox.Text == "Delila" && lozinkaTextBox.Password == "password")
            {
                Blagajna prozor = new Blagajna();
                prozor.Show();

            }
        }
    }
}
