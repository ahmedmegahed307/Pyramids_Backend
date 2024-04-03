using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.Enums
{
    public enum JobDateTypeEnum
    {

        [Description("NONE")]
        NONE,
        [Description("LOGGED")]
        LOGGED,
        [Description("ASSIGNED")]
        ASSIGNED,
        [Description("CLOSED")]
        CLOSED,
        [Description("SCHEDULED")]
        SCHEDULED,
        [Description("RESOLVED")]
        RESOLVED,
        [Description("CANCELLED")]
        CANCELLED
    }

}
