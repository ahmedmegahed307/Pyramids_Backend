using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.Enums
{
    public enum JobActionSourceEnum
    {
        NONE,

        [Description("Admin")]
        Admin,

        [Description("Client")]
        Client,

        [Description("Mobile")]
        Mobile,

        [Description("PPM")]
        PPM,
    }
}
