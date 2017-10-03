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