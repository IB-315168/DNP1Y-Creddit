using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients.ClientInterfaces
{
    public interface IAuthService
    {
        public Task LoginAsync(UserLoginDTO dto);
        public Task LogoutAsync();
        public Task RegisterAsync(User user);
        public Task<ClaimsPrincipal> GetAuthAsync();

        public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    }
}
