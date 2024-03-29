﻿//System
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MyIoT.Core.Utilities.Security.Encryption;

public class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
