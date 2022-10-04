using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class FileContext
    {
        private const string filePath = "data.json";

        private DataContainer? dataContainer;

        public ICollection<Post> Posts
        {
            get
            {
                LazyLoadData();
                return dataContainer!.Posts;
            }
        }

        public ICollection<User> Users
        {
            get
            {
                LazyLoadData();
                return dataContainer!.Users;
            }
        }

        private void LazyLoadData()
        {
            if (dataContainer == null)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            if (!File.Exists(filePath))
            {
                dataContainer = new()
                {
                    Posts = new List<Post>(),
                    Users = new List<User>()
                };
                return;
            }
            string content = File.ReadAllText(filePath);
            dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
        }

        public void SaveChanges()
        {
            string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, serialized);
            dataContainer = null;
        }
    }
}
