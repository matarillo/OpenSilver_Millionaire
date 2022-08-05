using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Millionaire
{
    public class CardImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(ImageSource))
                return null;
            Card c = value as Card;
            if (c == null)
                return null;
            string name = (c.Suit == Suit.Joker)
                ? "joker"
                : string.Format("{0}{1:00}", "cdhs"[(int)c.Suit], c.Number);
            return new BitmapImage(new Uri(string.Format("Images/{0}.png", name), UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
