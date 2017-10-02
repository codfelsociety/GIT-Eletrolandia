using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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

namespace AditionalControlsWPF
{
    public class Image
    {
        private byte[] uri;

        public Image(byte[] uri)
        {
            Imagem = uri;
        }

        public byte[] Imagem { get { return uri; } set { uri = value; } }
    }
    public partial class PicturePicker : UserControl, INotifyPropertyChanged
    {
        public PicturePicker()
        {
            Source = new List<byte[]>();
            InitializeComponent();
        }
        #region Propriedades
        public static DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(List<byte[]>), typeof(PicturePicker), new FrameworkPropertyMetadata(null, OnSourcePropertyChanged));
        public List<byte[]> Source
        {
            get
            {
                return (List<byte[]>)GetValue(SourceProperty);
            }
            set
            {
                SetValue(SourceProperty, value);
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
        private List<Image> imagens;
        public List<Image> Imagens
        {
            get
            {
                return imagens;
            }
            set
            {
                imagens = value;
                OnPropertyChanged("Imagens");
            }
        }
        #endregion

        private static void OnSourcePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            PicturePicker control = source as PicturePicker;
            try
            {
                List<byte[]> src = (List<byte[]>)e.NewValue;
                if (src == null) { control.Imagens = null; }
                else
                {
                    control.Imagens = null;
                    List<Image> l = new List<Image>();
                    foreach (byte[] imagem in src)
                    {
                        l.Add(new Image(imagem));
                    }
                    control.Imagens = l;
                }
            }
            catch (Exception) { }
        }
        public void Reset()
        {
            if (Source != null) Source = null;
            Imagens = null;
        }






        private void AdicionarImagem()
        {
            int count = (Source == null) ? 0 : Source.Count;
            if (count < Limit || Limit == 0)
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
                        if (Source == null)
                        {
                            List<byte[]> l = new List<byte[]>();
                            l.Add(Byte(imgSource));
                            Source = l;
                        }
                        else
                        {
                            Source.Add(Byte(imgSource));
                            Imagens = null;
                            List<Image> img = new List<Image>();
                            foreach (byte[] imagem in Source)
                            {
                                img.Add(new Image(imagem));
                            }
                            Imagens = img;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Limite permitido de imagens: " + Limit.ToString());
            }
        }
        public void RemoveSelectedItem()
        {
            if (Source.Count != 0)
            {
                Source.RemoveAt(listImages.SelectedIndex);
            }
            else
            {
                List<Image> img = new List<Image>();
                foreach (byte[] imagem in Source)
                {
                    img.Add(new Image(imagem));
                }
                Imagens = img;
            }
        }



        #region Notify
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Clicks
        private void recAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AdicionarImagem();
        }
        private void labelPlus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AdicionarImagem();
        }
        private void labelDeleteAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Reset();
        }
        private void recDeleteAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Reset();
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
        #endregion

        public static byte[] Byte(ImageSource imageSource)
        {
            PngBitmapEncoder p = new PngBitmapEncoder();
            BitmapEncoder encoder = p;
            byte[] bytes = null;
            var bitmapSource = imageSource as BitmapSource;
            if (bitmapSource != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                using (var stream = new MemoryStream())
                {
                    encoder.Save(stream);
                    bytes = stream.ToArray();
                }
            }
            return bytes;
        }
    }
}