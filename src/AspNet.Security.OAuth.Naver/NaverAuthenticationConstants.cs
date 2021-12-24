/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

namespace AspNet.Security.OAuth.Naver;

public static class NaverAuthenticationConstants
{
    public static class Claims
    {
        /// <summary>
        /// The claim for the user's age.
        /// </summary>
        public const string Age = "urn:naver:age";

        /// <summary>
        /// The claim for the user's year of birth.
        /// </summary>
        public const string YearOfBirth = "urn:naver:birthyear";
    }
}
