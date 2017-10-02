using System.Collections.ObjectModel;
using System.Windows.Controls;
using ProjetoTCC;

namespace ProjetoTCC.Assets.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        ObservableCollection<LanguageItem> CultureList = new ObservableCollection<LanguageItem>();
        public SettingsPage()
        {
            InitializeComponent();
            CultureList.Add(new LanguageItem{ ID =1, Photo = "../Icons/Flags/uk.png", Label = "English", Culture = "en-US" });
            CultureList.Add(new LanguageItem { ID = 2, Photo = "../Icons/Flags/br.png", Label = "Português", Culture = "pt-BR" });
           
            LanguageList.ItemsSource = CultureList;
            
        }
        public class LanguageItem
        {
            public int ID { get; set; }
            public string Photo { get; set; }
            public string Label { get; set; }
            public string Culture { get; set; }
        }

        private void LanguageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LanguageItem a = LanguageList.SelectedValue as LanguageItem;
            string b = a.Culture.ToString();
            App.SelectCulture(b);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
