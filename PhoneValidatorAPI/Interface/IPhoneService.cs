﻿using PhoneValidatorAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneValidatorAPI.Interface
{
    public interface IPhoneService
    {
        PhoneViewModel GetData(string phoneNumber);
    }
}
