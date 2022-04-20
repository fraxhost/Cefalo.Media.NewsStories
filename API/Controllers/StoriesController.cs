using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Pagination;
using Service.DTOs.Story;
using Service.Interfaces;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, General")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryService _storyService;

        public StoriesController(IStoryService storyService)
        {
            _storyService = storyService;
        }
        
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetStories([FromQuery] StoryParameterDto storyParameterDto)
        {
            var stories = await _storyService.GetStories(storyParameterDto);

            return Ok(stories);
        }
        
        
        [AllowAnonymous]
        [HttpGet("{storyId:int}",Name = "GetStory")]
        public async Task<IActionResult> GetStory(int storyId)
        {
            var story = await _storyService.GetStory(storyId);
        
            if (story == null)
            {
                return NotFound("Story not found!");
            }
            
            return Ok(story);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> CreateStory(CreateStoryDto createStoryDto)
        {
            if (createStoryDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _storyService.CreateStory(createStoryDto))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            // TODO: return 201 - Created At Action / route OR return 201 - Send Created Object
            return StatusCode(201);
        }

        
        [HttpPatch]
        public async Task<IActionResult> UpdateStory([FromBody] UpdateStoryDto updateStoryDto)
        {
            if (updateStoryDto == null)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.User.FindFirstValue("Id");
            if (userId != updateStoryDto.AuthorId && !HttpContext.User.IsInRole("Admin"))
            {
                return Unauthorized();
            }
            
            if (!await _storyService.UpdateStory(updateStoryDto))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {updateStoryDto.Id}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteStory([FromBody] DeleteStoryDto deleteStoryDto)
        {
            if (deleteStoryDto == null)
            {
                return BadRequest(ModelState);
            }

            var userId = HttpContext.User.FindFirstValue("Id");
            if (userId != deleteStoryDto.AuthorId && !HttpContext.User.IsInRole("Admin"))
            {
                return Unauthorized();
            }
            
            if (!await _storyService.StoryExists(deleteStoryDto.Id))
            {
                return NotFound();
            }

            var story = await _storyService.GetStory(deleteStoryDto.Id);

            if (!await _storyService.DeleteStory(story))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {story.Id}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}