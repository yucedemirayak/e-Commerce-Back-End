﻿using eCommerce.Core.Enums;
using System.Text.Json.Serialization;

namespace eCommerce.Api.DTOs.Admin
{
    public class SaveAdminDTO
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
