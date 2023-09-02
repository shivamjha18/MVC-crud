
using crudMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace crudMvc.Context
{
    public class PostContext:DbContext
    {
        public PostContext(DbContextOptions<PostContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}
