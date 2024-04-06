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
        OPEN=3,
        ASSIGNED=1,
        PENDING=4,
        RESOLVED=5,
        CANCELLED=6,
        CLOSED=2
    }
}
