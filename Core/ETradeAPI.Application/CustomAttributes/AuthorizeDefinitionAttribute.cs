using ETradeAPI.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.CustomAttributes
{
    public class AuthorizeDefinitionAttribute :Attribute
    {
        //yetkilendirmeye tabi tutacağım actionlarla ilgili bilgileri tutacağım
        public string  Menu { get; set; }
        public string Definition { get; set; }
        public ActionType ActionType { get; set; }
    }
}
