// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace ProductivityTools.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                 new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource("ProductivityTools.Meetings.API", "API for Meeting application"),
                new ApiResource("purchase.api", "API for purchase application")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "devmeetingsweb",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:3000/signin-callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:3000/index.html" },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:3000"
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ProductivityTools.Meetings.API"
                    }
                },
                new Client
                {
                    ClientId = "prodmeetingsweb",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "https://meetingsweb.z13.web.core.windows.net/signin-callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:3000/index.html" },
                    AllowedCorsOrigins =
                    {
                        "https://meetingsweb.z13.web.core.windows.net"
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ProductivityTools.Meetings.API"
                    }
                },

                 new Client
                {
                    ClientId = "purchase",
                    ClientName = "Purchase",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:3000/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:3000/signout-oidc" },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:3000"
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "purchase.api"
                    }
                },
                new Client
                {
                      ClientId = "WPFApplication",
                      AllowedGrantTypes = GrantTypes.ClientCredentials,
                      ClientSecrets =
                      {
                        new Secret("secret".Sha256())
                      },
                      AllowedScopes = { "ProductivityTools.Meetings.API" }
                },
                new Client
                {
                    ClientId = "MeetingsWpfApplication",
                   ClientName = "Native Client (Code with PKCE)",

                    RedirectUris = { "http://127.0.0.1/sample-wpf-app" },
                    PostLogoutRedirectUris = { "https://notused" },

                    RequireClientSecret = false,
                    RequireConsent = false,

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequirePkce = true,
                    AllowedScopes = { "openid", "profile" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse
                },
            };

    }
}