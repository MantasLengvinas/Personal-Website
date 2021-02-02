using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalUI.Data {
    public class AuthenticationProvider : AuthenticationStateProvider {

        private ISessionStorageService _sessionStorage;

        public AuthenticationProvider(ISessionStorageService sessionStorageService) {
            _sessionStorage = sessionStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync() {

            var username = await _sessionStorage.GetItemAsync<string>("username");
            ClaimsIdentity identity;

            if(username != null) {
                identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, username)
            }, "API");
            }
            else {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public async void MarkUserAsAuthenticated(string username) {

            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, username)
            }, "API");

            var user = new ClaimsPrincipal(identity);
            await _sessionStorage.SetItemAsync("username", username);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut() {

            _sessionStorage.RemoveItemAsync("username");

            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
