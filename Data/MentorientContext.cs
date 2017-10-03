using mentorient_api.Models;
using Microsoft.EntityFrameworkCore;

namespace mentorient_api.Data
{
    public class MentorientContext : DbContext
    {
        public MentorientContext(DbContextOptions<MentorientContext> options)
            : base(options)
        { }

        public DbSet<Video> Videos { get; set; }
    }
}