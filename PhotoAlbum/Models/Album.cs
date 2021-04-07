
namespace PhotoAlbum.Models
{
    public class Album
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        public Album(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
