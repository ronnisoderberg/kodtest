using kodtest.Models;
using Microsoft.EntityFrameworkCore;

namespace kodTest.Services
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        public DbSet<QuestionViewModel> Awnsers { get; set; }

        public DbSet<Flavour> Flavours { get; set; }
       
    }
}
