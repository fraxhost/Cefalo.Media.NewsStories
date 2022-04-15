using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service.DTOs.Pagination;
using Service.DTOs.Story;
using Service.Interfaces;

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryService _storyService;

        public StoriesController(IStoryService storyService)
        {
            _storyService = storyService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetStories([FromQuery] StoryParameterDto storyParameterDto)
        {
            var stories = await _storyService.GetStories(storyParameterDto);

            return Ok(stories);
        }
        
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
        
        [Authorize(AuthenticationSchemes = "Bearer")]
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
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPatch("{authorId:int}")]
        public async Task<IActionResult> UpdateStory(int authorId, [FromBody] UpdateStoryDto updateStoryDto)
        {
            if (updateStoryDto == null || authorId != updateStoryDto.AuthorId)
            {
                return BadRequest(ModelState);
            }

            if (!await _storyService.UpdateStory(updateStoryDto))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {updateStoryDto.Id}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{authorId:int}")]
        public async Task<IActionResult> DeleteStory(int authorId, [FromBody] DeleteStoryDto deleteStoryDto)
        {
            if (deleteStoryDto == null || authorId != deleteStoryDto.AuthorId)
            {
                return BadRequest(ModelState);
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