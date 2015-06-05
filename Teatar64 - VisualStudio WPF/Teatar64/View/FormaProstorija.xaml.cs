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
using Teatar64.ViewModel;
using Teatar64.Model;

namespace Teatar64.View
{
    /// <summary>
    /// Interaction logic for Prostorija.xaml
    /// </summary>
    public partial class FormaProstorija : Window
    {
        FormaDirektor parent { get; set; }
        public FormaProstorija(FormaDirektor p)
        {
            parent = p;
            InitializeComponent();
            parent.Focusable = false;
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            Prostorija p;
            if (TipComboBox.SelectedIndex == 0) p = new Sala(Convert.ToInt32(BrojMjestaTextBox.Text) ,Convert.ToString(NazivTextBox.Text));
            else p = new Teatar(Convert.ToInt32(BrojMjestaTextBox.Text) ,Convert.ToString(NazivTextBox.Text), Convert.ToDouble(VelicinaTextBox.Text));

            ProstorijaViewModel.UnesiProstoriju(p);
            BrojMjestaTextBox.Text = "";
            NazivTextBox.Text = "";
            TipComboBox.SelectedIndex = -1;
        }

        private void TeatarItem_Selected(object sender, RoutedEventArgs e)
        {
            velicinaLabel.Visibility = Visibility.Visible;
            VelicinaTextBox.Visibility = Visibility.Visible;
        }

        private void TeatarItem_Unselected(object sender, RoutedEventArgs e)
        {
            velicinaLabel.Visibility = Visibility.Hidden;
            VelicinaTextBox.Visibility = Visibility.Hidden;
        }

        private void PonistiButton_Click(object sender, RoutedEventArgs e)
        {
            BrojMjestaTextBox.Text = "";
            NazivTextBox.Text = "";
            TipComboBox.SelectedIndex = -1;
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.Focusable = true;
        }
    }
}
