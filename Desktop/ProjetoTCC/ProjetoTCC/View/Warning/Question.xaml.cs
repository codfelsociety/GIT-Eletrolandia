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
    /// Lógica interna para Question.xaml
    /// </summary>
    public partial class Question : Window
    {
        public Question(string title, string pergunta, int duration, string resposta1, string resposta2)
        {
            InitializeComponent();
            var vm = new ViewModel.QuestionViewModel(pergunta, title, duration, resposta1, resposta2);
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

        private int result = 0;
        public int Result
        {
            get { return result; }
            set { result = value; }
        }

        private void resp2_Click(object sender, RoutedEventArgs e)
        {
            Result = 2;
            Close();
        }

        private void resp1_Click(object sender, RoutedEventArgs e)
        {
            Result = 1;
            Close();
        }
    }
}
