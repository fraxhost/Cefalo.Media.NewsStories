﻿using System;

namespace Service.DTOs.Story
{
    public class StoryToReturnDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishedDate { get; set; }

        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
    }
}