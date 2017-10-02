using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;


namespace AditionalControlsWPF
{
    public partial class TextEditor : UserControl
    {
        public TextEditor()
        {
            InitializeComponent();
        }
        private void mitBold_Click(object sender, RoutedEventArgs e)
        {
            FontWeight bold = FontWeights.Bold;
            FontWeight regular = FontWeights.Regular;
            var selection = txtEditor.Selection;
            if (!selection.IsEmpty && selection.GetPropertyValue(TextElement.FontWeightProperty).ToString() != "Bold")
            {
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, bold);
                mitBold.Background = Brushes.LightGray;
            }
            else
            {
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, regular);
                mitBold.Background = Brushes.Transparent;
            }
        }

        private void cbxFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*   FontFamily family = new FontFamily(cbxFontFamily.SelectedItem.ToString());
                var selection = txtEditor.Selection;
                if (!selection.IsEmpty)
                    selection.ApplyPropertyValue(TextElement.FontFamilyProperty, family);*/
        }
        private void txtEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text = new TextRange(txtEditor.Document.ContentStart, txtEditor.Document.ContentEnd).Text;
        }
        private void txtEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            mitBold.Background = Brushes.Transparent;
            mitItalic.Background = Brushes.Transparent;
            var selection = txtEditor.Selection;
            if (selection.GetPropertyValue(TextElement.FontWeightProperty).ToString() == "Bold")
                mitBold.Background = Brushes.LightGray;
            if (selection.GetPropertyValue(TextElement.FontStyleProperty).ToString() == "Italic")
                mitItalic.Background = Brushes.LightGray;
        }

        private void mitItalic_Click(object sender, RoutedEventArgs e)
        {
            FontStyle italic = FontStyles.Italic;
            FontStyle normal = FontStyles.Normal;
            var selection = txtEditor.Selection;
            if (!selection.IsEmpty && selection.GetPropertyValue(TextElement.FontStyleProperty).ToString() != "Italic")
            {
                selection.ApplyPropertyValue(TextElement.FontStyleProperty, italic);
                mitItalic.Background = Brushes.LightGray;
            }
            else
            {
                selection.ApplyPropertyValue(TextElement.FontStyleProperty, normal);
                mitItalic.Background = Brushes.Transparent;
            }
        }



        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextEditor), new PropertyMetadata(OnTextCallBack));
        public string Text
        {
            get {return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        private static void OnTextCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TextEditor c = sender as TextEditor;
            if (c != null)
            {
                c.OnTextChanged();
            }
        }
        int count = 0;
        protected virtual void OnTextChanged()
        {
            if(count == 0)
            {
                count++;
                txtEditor.Document.Blocks.Add(new Paragraph(new Run(Text)));
            }
        }
    }
}
