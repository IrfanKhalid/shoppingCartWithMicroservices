﻿using SWT.Services.AuthAPI.Models;

namespace SWT.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}