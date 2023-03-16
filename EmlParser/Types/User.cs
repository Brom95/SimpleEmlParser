using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlParser.Types;
internal record User
{
    private string email;

    public string Email 
    { 
        get => email; 
        set => email = value.ToLower(); 
    }
    public string Name { get; set; }
}
