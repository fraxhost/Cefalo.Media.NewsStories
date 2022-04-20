using System;

namespace Service.DTOs.Story
{
    public class CreateStoryDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorId { get; set; }
    }
}