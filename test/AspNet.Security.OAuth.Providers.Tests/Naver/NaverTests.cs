/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using static AspNet.Security.OAuth.Naver.NaverAuthenticationConstants;

namespace AspNet.Security.OAuth.Naver;

public class NaverTests : OAuthTests<NaverAuthenticationOptions>
{
    public NaverTests(ITestOutputHelper outputHelper)
    {
        OutputHelper = outputHelper;
    }

    public override string DefaultScheme => NaverAuthenticationDefaults.AuthenticationScheme;

    protected internal override void RegisterAuthentication(AuthenticationBuilder builder)
    {
        builder.AddNaver(options => ConfigureDefaults(builder, options));
    }

    [Theory]
    [InlineData(ClaimTypes.NameIdentifier, "NpoHyTWpCXoCgGLV3Ew")]
    [InlineData(ClaimTypes.Name, "kasumielf")]
    [InlineData(ClaimTypes.Email, "example@naver.com")]
    [InlineData(ClaimTypes.DateOfBirth, "0828")]
    [InlineData(ClaimTypes.Gender, "male")]
    [InlineData(ClaimTypes.MobilePhone, "+821012341234")]
    public async Task Can_Sign_In_Using_Naver(string claimType, string claimValue)
    {
        // Arrange
        using var server = CreateTestServer();

        // Act
        var claims = await AuthenticateUserAsync(server);

        // Assert
        AssertClaim(claims, claimType, claimValue);
    }
}
