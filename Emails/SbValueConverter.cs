using System;
using System.Text;
using StatePrinting.ValueConverters;

namespace Emails
{
    public class SbValueConverter : IValueConverter
    {
        public bool CanHandleType(Type type) => type == typeof(StringBuilder);

        public string Convert(object source) => ((StringBuilder) source).ToString();
    }
}