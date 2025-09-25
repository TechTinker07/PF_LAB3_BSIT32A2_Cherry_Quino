using Microsoft.EntityFrameworkCore;
using PF_LAB3_BSIT32A2_Cherry_Quino.Models;

namespace PF_LAB3_BSIT32A2_Cherry_Quino.Data
{
    public class GreedDbContext : DbContext
    {
        public GreedDbContext(DbContextOptions<GreedDbContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}
