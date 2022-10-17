using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClients.Implementations
{
    public class UserHttpClient : IUserService
    {
        private readonly HttpClient client;

        public UserHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<User> CreateAsync(UserCreationDTO dto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/api/users", dto);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return user;
        }
    }
}
