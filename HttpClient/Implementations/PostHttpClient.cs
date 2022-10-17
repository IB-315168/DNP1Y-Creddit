﻿using Domain.Models;
using HttpClients.ClientInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClients.Implementations
{
    public class PostHttpClient : IPostService
    {
        private readonly HttpClient client;

        public PostHttpClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ICollection<Post>> GetAllAsync()
        {
            HttpResponseMessage response = await client.GetAsync("/api/posts");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

            return posts;
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"/api/posts/{id}");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            Post post = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;


            return post;
        }
    }
}