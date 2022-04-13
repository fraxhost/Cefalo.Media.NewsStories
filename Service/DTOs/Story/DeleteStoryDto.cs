﻿using System;

namespace Service.DTOs.Story
{
    public class DeleteStoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
    }
}