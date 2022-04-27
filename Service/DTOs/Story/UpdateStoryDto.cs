using System;

namespace Service.DTOs.Story
{
    public class UpdateStoryDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}