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

namespace ProjetoTCC.View.Warning
{
    /// <summary>
    /// Lógica interna para Warning.xaml
    /// </summary>
    public partial class Warning : Window
    {
        public Warning(string title, string message, int duration)
        {
            InitializeComponent();
            var vm = new ViewModel.WarningViewModel(message, title, duration);
            DataContext = vm;
            vm.ClosingRequest += (sender, e) => Close();

        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
