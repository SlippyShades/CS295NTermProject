using Microsoft.EntityFrameworkCore;
using MTG295NTermProject.Models;

namespace MTG295NTermProject.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CardModel> Cards { get; set; }

    }
}

