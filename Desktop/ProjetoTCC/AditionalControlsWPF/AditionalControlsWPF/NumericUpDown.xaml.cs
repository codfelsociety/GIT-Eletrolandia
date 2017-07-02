using System;
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

        #region Properties / Dependency Properties
        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown));
        private void d()
        {

        }
        public int Value
        {
            get
            {
                return (int)GetValue(ValueProperty);
            }
            set
            {
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
                return (int)GetValue(MaxValueProperty) ;
            }
            set
            {
                SetValue(MaxValueProperty, value);
            }
        }
        #endregion

        #region Checking user's Value
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]");
            return !regex.IsMatch(text);
        }
        private void txtValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        #endregion


        private void DefineValue(int val)
        {
            txtValue.Text = Convert.ToString(val);
            ValueChanged?.Invoke(this, EventArgs.Empty);

        }

        Color color = (Color)ColorConverter.ConvertFromString("#444");
        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            if (MaxValue != 0 && Value >= MaxValue)
            {
                Value--;
            }

            Value++;
            txtValue.Text = Value.ToString();
            btnDecrease.Foreground = new SolidColorBrush(color);
            btnDecrease.IsEnabled = true;
            ValueChanged?.Invoke(this, EventArgs.Empty);

        }

        private void btnDecrease_Click(object sender, RoutedEventArgs e)
        {

            if (Value > 0)
            {
                if (Value == 1)
                {
                    btnDecrease.Foreground = Brushes.DarkGray;
                    btnDecrease.IsEnabled = false;
                }
                Value--;
                txtValue.Text = Value.ToString();
            }

            ValueChanged?.Invoke(this, EventArgs.Empty);

        }
        public event EventHandler ValueChanged;
        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            decimal mwv = e.Delta / 120;
            if (mwv > 0)
            {
                if (MaxValue != 0 && Value >= MaxValue)
                {
                    Value--;
                }
                Value += (int)mwv * 1;
                txtValue.Text = Value.ToString();
                btnDecrease.Foreground = new SolidColorBrush(color);
                btnDecrease.IsEnabled = true;
            }
            else
            {
                if (Value > 0)
                {
                    if (Value == 1)
                    {
                        btnDecrease.Foreground = Brushes.DarkGray;
                        btnDecrease.IsEnabled = false;
                    }
                    Value += (int)mwv * 1;
                    txtValue.Text = Value.ToString();
                }

            }
            ValueChanged?.Invoke(this, EventArgs.Empty);

        }

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = txtValue.Text.Trim();
            if (texto == "")
            {
                Value = 0;
            }
            else if (texto.Length >= 10)
            {
                Value = 999999999;
                txtValue.Text =Value.ToString();
            }
            else
            {
                int valtexto = Convert.ToInt32(texto);
                if (MaxValue != 0 && valtexto >= MaxValue)
                {
                    Value = MaxValue;
                }
                else
                {
                    Value = valtexto;
                }
            }
            ValueChanged?.Invoke(this, EventArgs.Empty);

        }

        private void Grid1_Loaded(object sender, RoutedEventArgs e)
        {
            btnDecrease.IsEnabled = false;
            DefineValue(Value);
        }
    }
}
