using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoAlbum.Services
{
    public class ClientAPI : IClientAPI
    {
        private readonly string apiUrl;

        public ClientAPI(IConfiguration config)
        {
            apiUrl = config.GetSection("Api").Value;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            string apiResponse = await GetResponse(apiUrl + "/albums");
            return JsonConvert.DeserializeObject<IEnumerable<Album>>(apiResponse);
        }

        public async Task<IEnumerable<Comment>> GetCommnets(int idPhoto)
        {
            string apiResponse = await GetResponse(apiUrl + "/comments");
            var modelResponse = JsonConvert.DeserializeObject<IEnumerable<Comment>>(apiResponse);
            return modelResponse.Where(c => c.PostId == idPhoto);
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int idAlbum)
        {
            string apiResponse = await GetResponse(apiUrl + "/photos");
            var modelResponse = JsonConvert.DeserializeObject<IEnumerable<Photo>>(apiResponse);
            return modelResponse.Where(p => p.AlbumId == idAlbum);
        }

        private  async Task<string> GetResponse(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
