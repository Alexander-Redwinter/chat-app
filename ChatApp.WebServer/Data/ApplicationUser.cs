﻿using Microsoft.AspNetCore.Identity;

namespace ChatApp.WebServer
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
