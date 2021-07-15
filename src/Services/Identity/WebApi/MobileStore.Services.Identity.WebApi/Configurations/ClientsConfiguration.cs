using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Services.Identity.WebApi.Configurations
{
    public class ClientsConfiguration
    {
        public static List<IdentityResource> IdentityResources =>
        
              new List<IdentityResource>
              {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
              };
        
            

        public static IEnumerable<ApiResource> Apis =>
        
            new List<ApiResource>
            {
                new ApiResource("Catalog.Api", "Catalog api"),
            };
        
            

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId="Catalog.Api.Swagger",
                    ClientSecrets =
                    {
                        new Secret("CatalogSecret".Sha256()),
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes =
                    {
                        "Catalog.Api",
                        //IdentityServerConstants.StandardScopes.OpenId,
                        //IdentityServerConstants.StandardScopes.Profile
                    },
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser =true,
                    AccessTokenLifetime = 60*60*24*30
                },
            };
    }
}