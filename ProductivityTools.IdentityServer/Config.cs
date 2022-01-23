// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using ProductivityTools.MasterConfiguration;
using System.Collections.Generic;

namespace ProductivityTools.IdentityServer
{
    public static class Config
    {
        static IConfigurationRoot configuration = new ConfigurationBuilder().AddMasterConfiguration().Build();

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
                new ApiResource("purchase.api", "API for purchase application"),
                new ApiResource("GetTask3.API", "API for GetTask3 Application"),
                new ApiResource("Salaries.API", "API for Salaries Application")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "devmeetingsweb",
                    ClientName = "Development meetings web client",
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
                    ClientName = "Production Meetings Web client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime=17200,

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
                    },
                    AllowOfflineAccess=true
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
                        new Secret(configuration["MeetingsWPFApplication"].Sha256())
                      },
                      AllowedScopes = { "ProductivityTools.Meetings.API" }
                },
                new Client
                {
                      ClientId = "GetTask3Cmdlet",
                      AllowedGrantTypes = GrantTypes.ClientCredentials,
                      ClientSecrets =
                      {
                        new Secret(configuration["GetTask3Cmdlet"].Sha256())
                      },
                      AllowedScopes = { "GetTask3.API" }
                },
                new Client
                {
                    ClientId = "devtasks3web",
                    ClientName = "Development task3 web client",
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
                        "GetTask3.API"
                    }
                },
                new Client
                {
                    ClientId = "prodtasks3web",
                    ClientName = "Development task3 web client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "https://task3web.z13.web.core.windows.net/signin-callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:3000/index.html" },
                    AllowedCorsOrigins =
                    {
                        "https://task3web.z13.web.core.windows.net"
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "GetTask3.API"
                    }
                },

                  new Client
                {
                    ClientId = "devsalariesweb",
                    ClientName = "Development salaries web client",
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
                        "Salaries.API"
                    }
                  },
                     new Client
                {
                    ClientId = "prodsalariesweb",
                    ClientName = "Production salaries web client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "https://salariesweb.z35.web.core.windows.net/signin-callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:3000/index.html" },
                    AllowedCorsOrigins =
                    {
                        "https://salariesweb.z35.web.core.windows.net/"
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "GetTask3.API"
                    }
                },
                //new Client
                //{
                //    ClientId = "MeetingsWpfApplication",
                //   ClientName = "Native Client (Code with PKCE)",

                //    RedirectUris = { "http://127.0.0.1/sample-wpf-app" },
                //    PostLogoutRedirectUris = { "https://notused" },

                //    RequireClientSecret = false,
                //    RequireConsent = false,
                //    AccessTokenLifetime=10000, //?

                //    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                //    RequirePkce = true,
                //    AllowedScopes = { "openid", "profile" },

                //    AllowOfflineAccess = true,
                //    RefreshTokenUsage = TokenUsage.ReUse
                //},
            };

    }
}