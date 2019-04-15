using System;

namespace RazorComponentsRealworld.Model
{
    public class ArticleModel
    {
        public ArticleModel()
        {
            Author = new AuthorModel();
        }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public string[] TagList { get; set; }
        public string Description { get; set; }
        public AuthorModel Author { get; set; }
        public int FavoritesCount { get; set; }
    }

    public class AuthorModel
    {
        public string Username { get; set; }

        private string image;
        public string Image {
            get
            {
                Uri uri = new Uri(image);
                return "//" + uri.Host + uri.PathAndQuery;
            }
            set
            {
                image = value;
            }
        }
    }
}
