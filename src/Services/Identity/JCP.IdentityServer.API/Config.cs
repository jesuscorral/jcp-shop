using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace JCP.IdentityServer.API
{
    public class Config
    {
        // Resources or Apis is the part where the data source or web service we want to protect is defined.
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "CatalogAPI",
                    DisplayName = "Catalog API",
                    Description = "Allow the application to access API Catalog API on your behalf",
                    Scopes = new List<string> { "CatalogAPI.read", "CatalogAPI.write" },
                    ApiSecrets = new List<Secret> { new Secret("secret".Sha256()) }, // change me!
                    UserClaims = new List<string> { "role" }
                }
            };


        }

        // IdentityServer needs to know what client applications are allowed to use it.Clients that need to access the Api resource
        // are defined in the clients section.Each client application is defined in the Client object on the IdentityServer side.
        // A list of applications that are allowed to use your system.
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                   new Client
                   {
                        ClientId = "catalog-client",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = { "CatalogAPI.read", "CatalogAPI.write" }
                   },
                   new Client
                   {
                       ClientId = "ordering-client",
                       AllowedGrantTypes = GrantTypes.ClientCredentials,
                       ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = { "OrderingAPI" }
                   },
                   new Client
                   {
                       ClientId = "root-client",
                       AllowedGrantTypes = GrantTypes.ClientCredentials,
                       ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = { "OrderingAPI", "CatalogAPI" }
                   },
                   new Client
                   {
                        ClientId = "oidcClient",
                        ClientName = "Example Client Application",
                        ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
    
                        AllowedGrantTypes = GrantTypes.Code,
                        RedirectUris = new List<string> {"https://localhost:5002/signin-oidc"},
                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,
                            "role",
                            "CatalogAPI.read"
                        },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                   }
            };
        }

        // IdentityResource is information that includes user information such as userId, email, name,
        // has a unique name and we can assign claim types linked to them.Identity Resource information defined for a user is included
        // in the identity token.We can use Identity Resource that we defined with scope parameter in client settings.
        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResources.Email(),
              new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })
          };

        public static IEnumerable<ApiScope> ApiScopes =>
          new ApiScope[]
          {
               new ApiScope("CatalogAPI.read", "Read access catalog API"),
               new ApiScope("CatalogAPI.write", "Write access catalog API")
          };

        // Test users that will use the client applications need to access the Apis.
        // So for client application we should also defined test users.
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "mehmet",
                    Password = "swn",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "mehmet"),
                        new Claim(JwtClaimTypes.FamilyName, "ozkaya")
                    }
                }
            };
    }
}