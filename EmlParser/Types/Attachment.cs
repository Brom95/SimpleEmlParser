using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlParser.Types;
internal record Attachment
{
    public string FileName { get; set; }
    public string FullName { get; set; }
}
