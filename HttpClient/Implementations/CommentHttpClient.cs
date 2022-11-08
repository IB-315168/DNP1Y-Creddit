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
using System.Xml.Linq;

namespace HttpClients.Implementations
{
    public class CommentHttpClient : ICommentService
    {
        private readonly HttpClient client;

        public CommentHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Comment> CreateAsync(CommentCreationDTO dto, int id)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"/api/comment/{id}", dto);
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            Comment comment = JsonSerializer.Deserialize<Comment>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"/api/comment/{id}");
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            IEnumerable<Comment> comments = JsonSerializer.Deserialize<IEnumerable<Comment>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return comments;
        }
    }
}
