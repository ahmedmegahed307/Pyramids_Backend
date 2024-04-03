using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.Models.Email
{
    public class FileAttachment
    {
        public string Filename { get; set; }
        public byte[] StreamedData { get; set; }
    }
}
