﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using IdentityServer4;

namespace Marvin.IDP
{
    public static class Config
    {
        // Scopes listed under IdentityResources are the scopes that will be included in the ID-token.
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" }),
                new IdentityResource(
                    "country",
                    "The country you're living in",
                    new List<string>() { "country" }),
                new IdentityResource(
                    "subscriptionlevel",
                    "Your subscription level",
                    new List<string>() { "subscriptionlevel" })
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope(
                    "imagegalleryapi",
                    "Image Gallery API scope")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[] {
                new ApiResource("imagegalleryapi", "Image Gallery API")
                {
                    Scopes = { "imagegalleryapi"},
                    UserClaims = new List<string>() {"role"},
                    ApiSecrets = { new Secret("apisecret".Sha256())}
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {  new Client
                {
                    AccessTokenType = AccessTokenType.Reference,
                    IdentityTokenLifetime = 300, // 300 seconds (this is the default value)
                    AuthorizationCodeLifetime =  300, // 300 seconds (this is the default value)
                    AccessTokenLifetime = 120,  // default is one hour
                    AllowOfflineAccess = true,
                    // AbsoluteRefreshTokenLifetime = ..., // default is 30 days
                    // RefreshTokenExpiration = TokenExpiration.Sliding,
                    // kSlidingRefreshTokenLifetime = .... // default is 15 days
                    UpdateAccessTokenClaimsOnRefresh = true,
                    ClientName = "Image Gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = true,
                    RequirePkce = true,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:44389/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:44389/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "imagegalleryapi",
                        "country",
                        "subscriptionlevel"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
    }
}