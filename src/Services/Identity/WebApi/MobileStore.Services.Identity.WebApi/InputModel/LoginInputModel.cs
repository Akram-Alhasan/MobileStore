﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Services.Identity.WebApi.InputModel
{
    public class LoginInputModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
