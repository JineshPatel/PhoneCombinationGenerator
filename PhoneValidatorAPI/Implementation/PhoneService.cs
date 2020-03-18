using Microsoft.Extensions.Caching.Memory;
using PhoneValidatorAPI.Interface;
using PhoneValidatorAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneValidatorAPI.Implementation
{
    public class PhoneService : IPhoneService
    {
        private IMemoryCache _cache;
        public PhoneService(IMemoryCache cache)
        {
            _cache = cache;
        }      

        PhoneViewModel IPhoneService.GetData(string phoneNumber)
        {
            IList<string> result = new List<string>();

            Dictionary<char, String> phone = new Dictionary<char, string>() {
            {'2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" } };

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                string letters = phone.ContainsKey(phoneNumber[i]) ? phone[phoneNumber[i]] : "";

                foreach (var letter in letters)
                {
                    StringBuilder sb = new StringBuilder(phoneNumber);
                    sb[i] = letter;
                    result.Add(sb.ToString());
                }
            }
            var phoneViewModel = new PhoneViewModel() { phoneNumber=phoneNumber, Combinations = result, Total = result.Count };            
            return phoneViewModel;
        }
    }
}
