﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Queries.GetUserInfo
{
    public class GetUserInfoDto
    {
        public string? UserName { get; set;}
        public string? FirstName { get; set;}
        public string? LastName { get; set;}
        public string? Email { get; set;}
        public string? PhoneNumber { get; set;}
    }
}
