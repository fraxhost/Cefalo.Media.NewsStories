using System;

namespace DB.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishedDate { get; set; }

        
        public virtual string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}