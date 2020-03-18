using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneValidatorAPI.Model
{
    public class PageData
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
