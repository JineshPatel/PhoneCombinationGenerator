using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneValidatorAPI.ViewModel
{
    public class PhoneViewModel
    {
        public string phoneNumber { get; set; }
        public IList<string> Combinations { get; set; }
        public int Total { get; set; }
    }
}
