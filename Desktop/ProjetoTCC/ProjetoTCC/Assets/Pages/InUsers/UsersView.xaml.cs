using Microsoft.Win32;
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

namespace ProjetoTCC.Assets.Pages.InUsers
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : Page
    {
        public UsersView()
        {
            InitializeComponent();
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "img| *.bmp; *.jpg; *.png";
            fd.Multiselect = true;
            if (fd.ShowDialog() == true)
            {
                string[] files = fd.FileNames;
                foreach (string filename in files)
                {
                    Image img = new Image();
                    img.Source = new ImageSourceConverter().ConvertFromString(filename) as ImageSource;
                    img.Width = listImages.Height - 10;
                    img.UseLayoutRounding = true;


                    //img.Margin = new Thickness(0, 5, 5, 0);
                    listImages.Items.Add(img);
                    RenderOptions.SetBitmapScalingMode(img, BitmapScalingMode.HighQuality);
                    //dockPanel.Children.Add(img);
                }
            }
        }

        private void btnRemoveImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
