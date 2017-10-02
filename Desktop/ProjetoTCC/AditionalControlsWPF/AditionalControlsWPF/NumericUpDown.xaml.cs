using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AditionalControlsWPF
{
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown 
    {
        public NumericUpDown()
        {
            InitializeComponent();
        }

        #region Propriedades
        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown));
        public int Value
        {
            get
            {
                return (int)GetValue(ValueProperty);
            }
            set
            {
                int val = (int)GetValue(ValueProperty);
                if (val > MaxValue)
                    SetValue(ValueProperty, MaxValue);
                else
                    SetValue(ValueProperty, value);
            }
        }
        public static DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(int), typeof(NumericUpDown));
        public int MinValue
        {
            get
            {
                return (int)GetValue(MinValueProperty);
            }
            set
            {
                SetValue(MinValueProperty, value);
            }
        }
        public static DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(int), typeof(NumericUpDown));
        public int MaxValue
        {
            get
            {
                int i = (int)GetValue(MaxValueProperty);
                if (i != 0) return i; else return 9999;
            }
            set
            {
                SetValue(MaxValueProperty, value);
            }
        }
        #endregion

        bool ValidarMax()
        {
            int val = (int)GetValue(ValueProperty);
            if (val >= MaxValue) return false;

            return true;
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]");
            return !regex.IsMatch(text);
        }

        private void txtValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        #region Coisinhas
        Color color = (Color)ColorConverter.ConvertFromString("#444");
        public event EventHandler ValueChanged;
        #endregion

        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            if (MaxValue != 0 && Value >= MaxValue) { Value--; }
            Value++;
            btnDecrease.Foreground = new SolidColorBrush(color);
            btnDecrease.IsEnabled = true;
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnDecrease_Click(object sender, RoutedEventArgs e)
        {

            if (Value > 1)
            {
                if (Value == 2)
                {
                    btnDecrease.Foreground = Brushes.DarkGray;
                    btnDecrease.IsEnabled = false;
                }
                Value--;
            }

            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Grid1_Loaded(object sender, RoutedEventArgs e)
        {
            btnDecrease.IsEnabled = false;
        }

        private void Grid1_MouseWheel(object sender, MouseWheelEventArgs e)
        {

            decimal mwv = e.Delta / 120;
            if (mwv > 0)
            {
                if (MaxValue != 0 && Value >= MaxValue)
                {
                    Value--;
                }
                Value += (int)mwv * 1;
                btnDecrease.Foreground = new SolidColorBrush(color);
                btnDecrease.IsEnabled = true;
            }
            else
            {
                if (Value > 1)
                {
                    if (Value == 2)
                    {
                        btnDecrease.Foreground = Brushes.DarkGray;
                        btnDecrease.IsEnabled = false;
                    }
                    Value += (int)mwv * 1;
                }

            }
            ValueChanged?.Invoke(this, EventArgs.Empty);


        }
    }
}
