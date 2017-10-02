using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AditionalControlsWPF
{
    /// <summary>
    /// Interação lógica para MultiSelectComboBox.xam
    /// </summary>
    public partial class MultiSelectComboBox : UserControl
    {
        DataTable dt = new DataTable();
        int count = 0;
        public MultiSelectComboBox()
        {
            InitializeComponent();
            RequisitoInicial(count);
        }
        private void RequisitoInicial(int i)
        {
            if(i == 0)
            {
                try
                {
                    dt.Columns.Add("Valor");
                    dt.Columns.Add("Texto");
                }
                catch (Exception) { }
            }
            cb.SelectedValuePath = SelectedValuePath;
            cb.DisplayMemberPath = DisplayMemberPath;
            cb.ItemsSource = ItemsSource;
            lv.SelectedValuePath = "Valor";
        }
        protected virtual void OnItemsChanged()
        {
            if (count == 0)
            {
                count++;
                RequisitoInicial(count);
                AdicionarItems(null, SelectedItems,1);
            }
        }
        private string  ReturnSelectedItemValue(object sender, int index)
        {
            ComboBox cbx = (ComboBox)sender;
            string r = ((DataRowView)cbx.Items.GetItemAt(cbx.SelectedIndex)).Row.ItemArray[index].ToString();
            return r;
        }
        private void AdicionarItems(object sender, DataTable selectedItems, int d)
        {
            if(d == 0)
            {
                int c = Convert.ToInt32(ReturnSelectedItemValue(sender, 0));
                string v = ReturnSelectedItemValue(sender, 1);
                dt.Rows.Add(c, v);
                SelectedItems = RemoveDuplicates(dt);
                count++;
            }
            if (d==1)
            {
                foreach (DataRow r in selectedItems.Rows)
                {
                    int c = Convert.ToInt32(r[0].ToString());
                    string v = r[1].ToString();
                    dt.Rows.Add(c, v);
                }
            }
            lv.ItemsSource  = RemoveDuplicates(dt).DefaultView;
        }
        private void cb_Loaded(object sender, RoutedEventArgs e)
        {
            RequisitoInicial(count);
        }










        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdicionarItems(sender, null,0);
        }
        private void RemoveItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
            {
                DataRow[] rows;
                rows = dt.Select("Valor =" + lv.SelectedValue);
                foreach (DataRow row in rows)
                {
                    dt.Rows.Remove(row);
                }
                DataTable send = RemoveDuplicates(dt);
                lv.ItemsSource = send.DefaultView;
                SelectedItems = send;
            }
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
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cb.IsDropDownOpen = true;
        }

/// <summary>
/// NOTICE ME SENPAI ! NOTIME ME ! NOTICE ME SENPAI
/// </summary>
        public static DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(DataView), typeof(MultiSelectComboBox));
        public DataView ItemsSource
        {
            get
            {
                return (DataView)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }
        public static DependencyProperty SelectedValuePathProperty = DependencyProperty.Register("SelectedValuePath", typeof(string), typeof(MultiSelectComboBox));
        public string SelectedValuePath
        {
            get
            {
                return (string)GetValue(SelectedValuePathProperty);
            }
            set
            {
                SetValue(SelectedValuePathProperty, value);
            }
        }
        private static DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(MultiSelectComboBox));
        public string DisplayMemberPath
        {
            get
            {
                return (string)GetValue(DisplayMemberPathProperty);
            }
            set
            {
                SetValue(DisplayMemberPathProperty, value);
            }
        }
        public static DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(DataTable), typeof(MultiSelectComboBox), new PropertyMetadata(OnSelectedItemsCallBack));
        public DataTable SelectedItems
        {
            get { return (DataTable)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }
        private static void OnSelectedItemsCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox c = sender as MultiSelectComboBox;
            if (c != null)
            {
                c.OnItemsChanged();
            }
        }
    }
}
