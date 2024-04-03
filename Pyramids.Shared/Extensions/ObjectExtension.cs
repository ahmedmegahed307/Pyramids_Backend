using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Shared.Extensions
{
    public static partial class ObjectExtension
    {

        public static string ToDescriptionString(this object data)
        {
            if (data != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])data.GetType().GetField(data.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : string.Empty;
            }
            return string.Empty;
        }
    }
}
