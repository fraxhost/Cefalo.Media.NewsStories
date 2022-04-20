using System;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Story
{
    public class DeleteStoryDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string AuthorId { get; set; }
    }
}