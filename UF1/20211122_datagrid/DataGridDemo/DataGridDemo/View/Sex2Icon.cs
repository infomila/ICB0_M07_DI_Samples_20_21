using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DataGridDemo.View
{
    public class Sex2Icon:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((Boolean)value) ? "♂" : "♀";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
