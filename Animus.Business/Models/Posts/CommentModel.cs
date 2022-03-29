using Animus.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animus.Business.Models.Posts
{
    public class CommentModel
    {
        public Guid ParentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
        public Guid SectionId { get; set; }
    }
}
