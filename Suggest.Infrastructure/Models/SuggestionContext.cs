using Microsoft.EntityFrameworkCore;
using Suggest.Services.Entities;

namespace Suggest.Infrastructure.Models
{
    public class SuggestionContext : DbContext
    {
        public SuggestionContext(DbContextOptions<SuggestionContext> options)
            : base(options)
        {
        }

        public DbSet<Suggestion> Suggestions { get; set; }
    }
}
