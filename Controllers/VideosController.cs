using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mentorientApi.Models;
using mentorientApi.Data;
using System.Linq;

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
        public IEnumerable<Video> Get()
        {
            return _context.Videos.ToList();

        }

        // POST api/videos
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

        // GET api/videos/id
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var video = _context.Videos.FirstOrDefault(v => v.VideoId == id);

            if (video == null)
            {
                return NotFound();
            }

            return new ObjectResult(video);
        }

        // PUT api/videos/id
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Video video)
        {
            var videoInDb = _context.Videos.FirstOrDefault(v => v.VideoId == id);
           
            videoInDb.Title = video.Title;
            videoInDb.Description = video.Description;
            videoInDb.Source = video.Source;

            _context.Videos.Update(videoInDb);
            _context.SaveChanges();

            return new NoContentResult();
        }

        // DELETE api/videos/id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var video = _context.Videos.FirstOrDefault(v => v.VideoId == id);
            if (video == null)
            {
                return NotFound();
            }

            _context.Videos.Remove(video);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}