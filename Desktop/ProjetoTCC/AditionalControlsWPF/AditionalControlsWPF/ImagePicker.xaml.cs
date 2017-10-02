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

        public ImageSource FirstPicture()
        {
            try
            {
                return SelectedPaths.Rows[0]["Image"] as ImageSource; 
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static DependencyProperty LimitProperty = DependencyProperty.Register("Limit", typeof(int), typeof(ImagePicker));
        public int Limit
        {
            get
            {
                return (int)GetValue(LimitProperty);
            }
            set
            {
                SetValue(LimitProperty, value);
            }
        }
        public static DependencyProperty PictureProperty = DependencyProperty.Register("Picture", typeof(ImageSource), typeof(ImagePicker));
        public ImageSource Picture
        {
            get
            {
                return (ImageSource)GetValue(PictureProperty);
            }
            set
            {
                SetValue(PictureProperty, value);
            }
        }
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
            foreach (DataRowView p in Source)
            {
                ImageSource imgSource = LoadImage(p[1] as byte[]);
                dt.Rows.Add(Convert.ToInt32(p[0].ToString()), imgSource);
            }
            listImages.ItemsSource = dt.DefaultView;
            SelectedPaths = dt;

            Picture = FirstPicture();
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
            int count = 0;
            if (SelectedPaths == null) count = 0; else count = SelectedPaths.Rows.Count;
            
            if (count < Limit || Limit == 0) {
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
                Picture = FirstPicture();

            }
            else
            {
                MessageBox.Show("Limite permitido de imagens: " + Limit.ToString());
            }
        }
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
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
            Picture = FirstPicture();

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
