﻿namespace MyIoT.Core.Utilities.Security.JWT;

public class TokenOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public double TokenExpire { get; set; }
    public string SecurityKey { get; set; }
}
