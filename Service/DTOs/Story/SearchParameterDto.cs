using Service.DTOs.Pagination;

namespace Service.DTOs.Story
{
    public class SearchParameterDto : RequestParameterDto
    {
        public string SearchString { get; set; }
    }
}