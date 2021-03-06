﻿using System;
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
    /// Interaction logic for FormaProducent.xaml
    /// </summary>
    public partial class FormaProducent : Window
    {
        MainWindow login { get; set; }
        private List<Recenzija> _recenzijasource;
        public List<Recenzija> RecenzijaSource
        {
            get
            {
                KameniTeatar64 baza = new KameniTeatar64();
                _recenzijasource = baza.UcitajRecenzije();
                return _recenzijasource;
            }
            set
            {
                _recenzijasource = value;
            }
        }
        public FormaProducent(MainWindow l)
        {
            login = l;
            InitializeComponent();
            UcitajRecenzije();
        }
        private void UcitajRecenzije()
        {
            RecenzijeDataGrid.ItemsSource = RecenzijaSource;
        }
        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            login.OcistiPodatke();
            login.Show();
        }

        private void DodajPredstavuButton_Click(object sender, RoutedEventArgs e)
        {
            FormaPredstave prozor = new FormaPredstave(this);
            prozor.Show();
        }
    }
}
