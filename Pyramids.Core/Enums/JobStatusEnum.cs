using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.Enums
{
    public enum JobStatusEnum
    {
        NONE,
        OPEN=1,
        ASSIGNED=2,
        PENDING=3,
        RESOLVED=4,
        CANCELLED=5,
        CLOSED=7
    }
}
