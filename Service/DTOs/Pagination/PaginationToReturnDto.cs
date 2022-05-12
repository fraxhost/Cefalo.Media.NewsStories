using System.Collections.Generic;
using Service.DTOs.Story;

namespace Service.DTOs.Pagination
{
    public class PaginationToReturnDto
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int Count { get; set; }
        public IEnumerable<StoryToReturnDto> Data { get; set; }
    }
}