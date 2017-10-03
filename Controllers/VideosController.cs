using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mentorientApi.Models;
using mentorientApi.Data;

namespace mentorientApi.Controllers
{
    [Route("api/[controller]")]
    public class VideosController : Controller
    {
        private readonly MentorientContext _context;
        public VideosController(MentorientContext context )
        {
            _context = context;
        }

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

            _context.Add(video);
            _context.SaveChanges();
            
            return new ObjectResult(video);
        }

    }
}