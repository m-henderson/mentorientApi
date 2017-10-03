using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mentorientApi.Models;

namespace mentorientApi.Controllers
{
    [Route("api/[controller]")]
    public class VideosController : Controller
    {
        // GET api/videos
        [HttpGet]
        public Video Get()
        {
            var video = new Video
            {
                VideoId = 1, 
                Title = "How to type", 
                Description = "video on how to type faster",
                Source = "~/how-to-type.mp4"
            };
            return video;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Video video)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            
            return new ObjectResult(video);
        }

    }
}