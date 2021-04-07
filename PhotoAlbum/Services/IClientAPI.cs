using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Services
{
    public interface IClientAPI
    {
        Task<IEnumerable<Album>> GetAlbums();

        Task<IEnumerable<Photo>> GetPhotos(int idAlbum);

        Task<IEnumerable<Comment>> GetCommnets(int idPhoto);

    }
}
