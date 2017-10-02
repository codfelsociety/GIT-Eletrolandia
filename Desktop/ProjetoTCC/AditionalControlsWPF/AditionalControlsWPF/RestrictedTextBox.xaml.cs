using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AditionalControlsWPF
{
    /// <summary>
    /// Interação lógica para RestrictedTextBox.xam
    /// </summary>
    public partial class RestrictedTextBox : UserControl, INotifyPropertyChanged
    {
        public RestrictedTextBox()
        {
            InitializeComponent();
        }
        public static DependencyProperty RestrictedToProperty = DependencyProperty.Register("RestrictedTo", typeof(string), typeof(RestrictedTextBox));
        public string RestrictedTo
        {
            get
            {
                return (string)GetValue(RestrictedToProperty);
            }
            set
            {
                SetValue(RestrictedToProperty, value);
            }
        }

        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(Brush), typeof(RestrictedTextBox), new PropertyMetadata(Brushes.Transparent));
        public Brush BorderColor
        {
            get
            {
                return (Brush)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
                OnPropertyChanged("BorderColor");
            }
            
        }


       
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(RestrictedTextBox), new PropertyMetadata("DEFAULT"));
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
                OnPropertyChanged("Text");
            }
        }

     
        private static bool Letter(string text)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            return !regex.IsMatch(text);
        }
        private static bool Number(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
        private void controleTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (RestrictedTo == "LettersOnly")
                e.Handled = Letter(e.Text);
            if (RestrictedTo == "NumbersOnly")
                e.Handled = Number(e.Text);

        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
