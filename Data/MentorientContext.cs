using mentorientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mentorientApi.Data
{
    public class MentorientContext : DbContext
    {
        public MentorientContext(DbContextOptions<MentorientContext> options)
            : base(options)
            {
            }

        public DbSet<Video> Videos { get; set; }
    }
}