using addons_ts_lab_puppiesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace addons_ts_lab_puppiesApi.Data
{
    public class PuppyDbContext : DbContext
    {
        public PuppyDbContext(DbContextOptions options) : base(options)
        {
        }

        // This is fuzzy search using SOUNDEX built in function
        [DbFunction(name: "SOUNDEX", IsBuiltIn = true)]
        public string FuzzySearch(string query)
        {
            throw new Exception();
        }
        public DbSet<Puppy> Puppies { get; set; } 
    }
}