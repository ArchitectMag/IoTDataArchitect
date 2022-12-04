//System
using System;

namespace MyIoT.Core.Utilities.Security.JWT;

public class AccessToken
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpireDate { get; set; }
}
