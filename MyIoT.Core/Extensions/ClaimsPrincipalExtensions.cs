﻿//System
using System.Security.Claims;

namespace MyIoT.Core.Extensions;

public static class ClaimsPrincipalExtensions
{
	public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
	{
		var result = claimsPrincipal?.FindAll(claimType)?.Select(c=>c.Value).ToList();
		return result;
	}

    public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
    {
		return claimsPrincipal?.Claims(ClaimTypes.Role);
    }
}

