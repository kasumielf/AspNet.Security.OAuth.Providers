/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using System.Security.Claims;
using static AspNet.Security.OAuth.Naver.NaverAuthenticationConstants;

namespace AspNet.Security.OAuth.Naver;

public class NaverAuthenticationOptions : OAuthOptions
{
    public NaverAuthenticationOptions()
    {
        ClaimsIssuer = NaverAuthenticationDefaults.Issuser;
        CallbackPath = NaverAuthenticationDefaults.CallbackPath;

        AuthorizationEndpoint = NaverAuthenticationDefaults.AuthorizationEndpoint;
        TokenEndpoint = NaverAuthenticationDefaults.TokenEndpoint;
        UserInformationEndpoint = NaverAuthenticationDefaults.UserInformationEndpoint;

        ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "response", "id");
        ClaimActions.MapJsonKey(ClaimTypes.Name, "response", "name");
        ClaimActions.MapJsonKey(ClaimTypes.Email, "response", "email");
        ClaimActions.MapJsonKey(ClaimTypes.Gender, "response", "gender");
        ClaimActions.MapJsonKey(Claims.Age, "response", "age");
        ClaimActions.MapJsonKey(ClaimTypes.DateOfBirth, "response", "birthday");
        ClaimActions.MapJsonKey(Claims.YearOfBirth, "response", "birthyear");
        ClaimActions.MapJsonKey(ClaimTypes.MobilePhone, "response", "mobile");
    }
}
