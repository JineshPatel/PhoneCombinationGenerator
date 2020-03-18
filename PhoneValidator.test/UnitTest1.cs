using Moq;
using NUnit.Framework;
using PhoneValidatorAPI.Controllers;
using PhoneValidatorAPI.Interface;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

using PhoneValidatorAPI.Model;
using Microsoft.AspNetCore.Mvc;
using PhoneValidatorAPI.ViewModel;
using System.Collections.Generic;
using PhoneValidatorAPI.Implementation;

namespace Tests
{
    public class Tests
    {
        public Mock<IPhoneService> phoneService {get;set;}
        public Mock<IMemoryCache> memoryCache { get; set; }      

        [Test]
        public void GetPhoneCombinations()
        {
            phoneService = new Mock<IPhoneService>();
            phoneService.Setup(x => x.GetData("4407492743")).Returns(new PhoneViewModel { Combinations = new List<string>{ "g407492743", "h407492743", "i407492743", "4g07492743", "4h07492743", "4i07492743", "440p492743", "440q492743", "440r492743", "440s492743" },Total =30 });
            memoryCache = new Mock<IMemoryCache>();
            PageData pageData = new PageData() {PageNumber = 1, PageSize = 10 ,PhoneNumber= "4407492743" };
            PhoneController phoneController = new PhoneController(phoneService.Object,memoryCache.Object);

            IActionResult actionResult = phoneController.GetPhoneCombination("4407492743");
            OkObjectResult contentresult = actionResult as OkObjectResult;

            var result = contentresult.Value as PhoneViewModel;

            Assert.IsNotNull(contentresult);
            Assert.IsNotNull(contentresult.Value);
            Assert.AreEqual(30, result.Total);
            Assert.AreEqual(10, result.Combinations.Count);
        }

        [Test]
        public void PhoneServiceGetData()
        {
            memoryCache = new Mock<IMemoryCache>();

            IPhoneService phoneService = new PhoneService(memoryCache.Object);

            var data = phoneService.GetData("4407492743");

            Assert.AreEqual(30,data.Combinations.Count);
            Assert.AreEqual(30, data.Total);
        }
    }
}