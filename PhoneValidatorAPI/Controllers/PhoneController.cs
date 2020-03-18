using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PhoneValidatorAPI.Interface;
using PhoneValidatorAPI.Model;
using PhoneValidatorAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneValidatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private IPhoneService _phoneService;
        private IMemoryCache _memoryCache;
        private PhoneViewModel _data;
        private string _phoneNo;
        public PhoneController(IPhoneService phoneService,IMemoryCache cache)
        {
            _phoneService = phoneService;
            _memoryCache = cache;
        }
        [Route("GetPhoneCombination/{phoneNumber}")]
        [HttpGet]
        public IActionResult GetPhoneCombination([FromRoute]string phoneNumber)
        {
         
             _data = _phoneService.GetData(phoneNumber);
            return new OkObjectResult(_data);
        }
       
        [Route("GetPhoneCombination")]
        [HttpGet]
        public IActionResult GetPhoneCombination([FromQuery]PageData page)
        {
            PhoneViewModel data;
            if (_memoryCache.TryGetValue("phoneData" + page.PhoneNumber, out data))
            {
                 _data = data;
            }
            else
            {
                _data = _phoneService.GetData(page.PhoneNumber);
                _memoryCache.Set("phoneData"+page.PhoneNumber, _data);
            }                     
          
            return new OkObjectResult(  new PhoneViewModel() { Combinations = _data.Combinations.Skip((page.PageNumber - 1 ) * page.PageSize).Take(page.PageSize).ToList(), Total = _data.Total });            
        }
    }
}
