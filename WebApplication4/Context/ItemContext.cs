using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Context
{
    public class ItemContext :DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options):base(options) 
        { 

        }
        public DbSet<Item> Items { get; set; }
    }
}
