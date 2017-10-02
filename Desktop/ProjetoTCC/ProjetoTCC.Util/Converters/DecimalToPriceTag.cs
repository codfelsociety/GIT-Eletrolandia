using System;
using System.Globalization;
using System.Windows.Data;

namespace Util.Convert
{
    [ValueConversion(typeof(decimal), typeof(string))]
    public class DecimalToPriceTag : IValueConverter
    {
        public static DecimalToPriceTag Instance = new DecimalToPriceTag();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal preco;
            try { preco = (decimal)value; } catch { return 0; }
            return String.Format("{0:C}", preco).ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
