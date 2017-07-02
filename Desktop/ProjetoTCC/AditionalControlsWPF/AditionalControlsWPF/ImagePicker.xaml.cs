using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AditionalControlsWPF
{

    public partial class ImagePicker : UserControl
    {
        public ImagePicker()
        {
            dt.Columns.Add("cod");
            dt.Columns.Add("Image", typeof(ImageSource));
            InitializeComponent();
            listImages.SelectedValuePath = "cod";

        }
        DataTable dt = new DataTable();

        public static DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(DataView), typeof(ImagePicker));
        public DataView Source
        {
            get
            {
                return (DataView)GetValue(SourceProperty);
            }
            set
            {
                SetValue(SourceProperty, value);
            }
        }
        public static DependencyProperty SelectedPathsProperty = DependencyProperty.Register("SelectedPaths", typeof(DataTable), typeof(ImagePicker));
        public DataTable SelectedPaths
        {
            get
            {
                return (DataTable)GetValue(SelectedPathsProperty);
            }
            set
            {
                SetValue(SelectedPathsProperty, value);
            }
        }
        public void CarregarSource()
        {
            foreach (DataRowView r in Source)
            {
                byte[] blob = r[1] as byte[];
                ImageSource imgSource = LoadImage(blob);
                dt.Rows.Add(Convert.ToInt32(r[0].ToString()), imgSource);
            }
            listImages.ItemsSource = dt.DefaultView;
            SelectedPaths = dt;
        }
        private DataTable RemoveDuplicates(DataTable entrada)
        {
            DataTable saida = entrada;
            var UniqueRows = entrada.AsEnumerable().Distinct(DataRowComparer.Default);
            int i = 0;
            foreach (DataRow row in entrada.Rows)
            {
                i++;
            }
            if (i != 0)
            {
                saida = UniqueRows.CopyToDataTable();
            }
            return saida;
        }
        private void listImages_Loaded(object sender, RoutedEventArgs e)
        {
            if (Source != null)
            {
                CarregarSource();
            }
        }
        int i = 999;
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        private void AdicionarImagem()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "img| *.bmp; *.jpg; *.png";
            fd.Multiselect = true;
            if (fd.ShowDialog() == true)
            {
                string[] files = fd.FileNames;
                foreach (string filename in files)
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(filename));
                    ImageSource imgSource = bitmap;
                    i++;
                    dt.Rows.Add(i, imgSource);
                }
            }
            listImages.ItemsSource = dt.DefaultView;
            SelectedPaths = dt;
        }
        private void Rectangle_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
            {
                RemoveSelectedItem();
            }
        }
        private void labelX_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
            {
                RemoveSelectedItem();
            }
        }
        private void recAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AdicionarImagem();
        }
        private void labelPlus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AdicionarImagem();
        }
        private void RemoveSelectedItem()
        {
            DataRow row = dt.Select("cod=" + listImages.SelectedValue.ToString()).First();
            dt.Rows.Remove(row);
            listImages.ItemsSource = RemoveDuplicates(dt).DefaultView;
        }
        private void ClearList()
        {
            dt.Rows.Clear();
            listImages.ItemsSource = dt.DefaultView;
            SelectedPaths = dt;
        }
        private void labelDeleteAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClearList();
        }
        private void recDeleteAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClearList();
        }
    }
}
