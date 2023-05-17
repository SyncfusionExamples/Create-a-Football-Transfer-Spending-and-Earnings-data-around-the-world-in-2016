using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FootballSpentEarned
{
    public class ImageConverter : IValueConverter
    {
        string Text { set; get; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Text = value as string;

            if (Text.Contains(" ") || Text.Contains("�") || Text.Contains("ü") ||
                Text.Contains("é") || Text.Contains("á") || Text.Contains("'"))
            {
                Text = Text.Replace(" ", "_").ToLower() + ".png";
                Text = Text.Replace("&", "_");
                Text = Text.Replace("�", "_");
                Text = Text.Replace("ü", "_");
                Text = Text.Replace("é", "_");
                Text = Text.Replace("á", "_");
                Text = Text.Replace("'", "_");
                Text = Text.Replace("î", "_");
                Text = Text.Replace("-", "_");
            }
            else if (!Text.Contains(".png"))
            {
                Text = Text.ToLower() + ".png";
            }

            if (Text.Contains("0") || Text.Contains("5") || Text.Contains("4"))
            {
                Text = Text.Replace("_05", "");
                Text = Text.Replace("_04", "");
            }

            Text = "/FootballSpentEarned;component/ClubIcons/" + Text;
            return Text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                var data = value as LegendItem;
                string image = data.Series.Label;
                if(image.Contains(" "))
                {
                    image = image.Replace(" ", "_");
                    image = image + ".png";
                }

                if(image.Contains("1"))
                {
                    image = image.Replace("1", "");
                }
                
                image = "/FootballSpentEarned;component/ImageIcons/" + image;
               
                return image;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(value != null)
            {
                if (value is FootballMarket items)
                {
                    SolidColorBrush solidColorBrush = new SolidColorBrush();
                    FootballMarket data = items;
                    if (data.LeagueCode == "ENG")
                    {
                        solidColorBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#d61111"));
                    }
                    else if (data.LeagueCode == "ESP")
                    {
                        solidColorBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#e19620"));
                       
                    }
                    else if (data.LeagueCode == "FRA")
                    {
                       
                        solidColorBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#00008B"));
                    }
                    else if (data.LeagueCode == "GER")
                    {
                        solidColorBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                      
                    }
                    else if (data.LeagueCode == "ITA")
                    {
                        solidColorBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#49a349"));
                    }
                    return solidColorBrush;
                }
            }
           return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
