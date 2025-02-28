﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

namespace AspNet.Security.OAuth.Keycloak;

public class KeycloakTests : OAuthTests<KeycloakAuthenticationOptions>
{
    public KeycloakTests(ITestOutputHelper outputHelper)
    {
        OutputHelper = outputHelper;
    }

    public override string DefaultScheme => KeycloakAuthenticationDefaults.AuthenticationScheme;

    protected internal override void RegisterAuthentication(AuthenticationBuilder builder)
    {
        builder.AddKeycloak(options =>
        {
            ConfigureDefaults(builder, options);
            options.Domain = "keycloak.local";
            options.Realm = "myrealm";
        });
    }

    [Theory]
    [InlineData(ClaimTypes.NameIdentifier, "995c1500-0dca-495e-ba72-2499d370d181")]
    [InlineData(ClaimTypes.Email, "john@smith.com")]
    [InlineData(ClaimTypes.GivenName, "John")]
    [InlineData(ClaimTypes.Role, "admin")]
    [InlineData(ClaimTypes.Name, "John Smith")]
    public async Task Can_Sign_In_Using_Keycloak_BaseAddress(string claimType, string claimValue)
    {
        // Arrange
        static void ConfigureServices(IServiceCollection services)
        {
            services.PostConfigureAll<KeycloakAuthenticationOptions>((options) =>
            {
                options.BaseAddress = new Uri("http://keycloak.local:8080");
            });
        }

        using var server = CreateTestServer(ConfigureServices);

        // Act
        var claims = await AuthenticateUserAsync(server);

        // Assert
        AssertClaim(claims, claimType, claimValue);
    }

    [Theory]
    [InlineData(ClaimTypes.NameIdentifier, "995c1500-0dca-495e-ba72-2499d370d181")]
    [InlineData(ClaimTypes.Email, "john@smith.com")]
    [InlineData(ClaimTypes.GivenName, "John")]
    [InlineData(ClaimTypes.Role, "admin")]
    [InlineData(ClaimTypes.Name, "John Smith")]
    public async Task Can_Sign_In_Using_Keycloak_Domain(string claimType, string claimValue)
    {
        // Arrange
        static void ConfigureServices(IServiceCollection services)
        {
            services.PostConfigureAll<KeycloakAuthenticationOptions>((options) =>
            {
                options.Domain = "keycloak.local";
            });
        }

        using var server = CreateTestServer(ConfigureServices);

        // Act
        var claims = await AuthenticateUserAsync(server);

        // Assert
        AssertClaim(claims, claimType, claimValue);
    }

    [Theory]
    [InlineData(ClaimTypes.NameIdentifier, "995c1500-0dca-495e-ba72-2499d370d181")]
    [InlineData(ClaimTypes.Email, "john@smith.com")]
    [InlineData(ClaimTypes.GivenName, "John")]
    [InlineData(ClaimTypes.Role, "admin")]
    [InlineData(ClaimTypes.Name, "John Smith")]
    public async Task Can_Sign_In_Using_Keycloak_Public_AccessType(string claimType, string claimValue)
    {
        // Arrange
        static void ConfigureServices(IServiceCollection services)
        {
            services.PostConfigureAll<KeycloakAuthenticationOptions>((options) =>
            {
                options.AccessType = KeycloakAuthenticationAccessType.Public;
                options.ClientSecret = string.Empty;
                options.Domain = "keycloak.local";
            });
        }

        using var server = CreateTestServer(ConfigureServices);

        // Act
        var claims = await AuthenticateUserAsync(server);

        // Assert
        AssertClaim(claims, claimType, claimValue);
    }
}
