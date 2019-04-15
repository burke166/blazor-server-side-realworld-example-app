using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorComponentsRealworld.Model
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public AuthorModel Author { get; set; }

    }
}
