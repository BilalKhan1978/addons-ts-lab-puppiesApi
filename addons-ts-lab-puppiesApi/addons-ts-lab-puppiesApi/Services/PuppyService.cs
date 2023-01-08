using addons_ts_lab_puppiesApi.Data;
using addons_ts_lab_puppiesApi.Models;
using addons_ts_lab_puppiesApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace addons_ts_lab_puppiesApi.Services
{
    public class PuppyService : IPuppyService
    {
        private readonly PuppyDbContext _dbContext;
        public PuppyService(PuppyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Puppy>> GetAllPuppies()
        {
            return await _dbContext.Puppies.ToListAsync(); 
        }
        public async Task<Puppy> GetPuppyById(Guid id)
        {
           var puppy = await _dbContext.Puppies.FindAsync(id);
            if (puppy == null)
                throw new Exception("No Record Found");
            return puppy;   
        }
        public async Task<Puppy> AddPuppy(AddPuppyRequestDto addPuppyRequestDto)
        {
            var puppy = new Puppy()
            {
                Id = new Guid(),
                Name = addPuppyRequestDto.Name,
                Breed = addPuppyRequestDto.Breed,
                BirthDate = addPuppyRequestDto.BirthDate,
            };
            await _dbContext.Puppies.AddAsync(puppy);
            await _dbContext.SaveChangesAsync();
            return puppy;
        }
        public async Task UpdatePuppy(Guid id,UpdatePuppyRequestDto updatePuppyRequestDto)
        {
            var puppy = await _dbContext.Puppies.FindAsync(id);
            if (puppy==null)
            {
                throw new Exception("Not Found");
            }
            puppy.Name = updatePuppyRequestDto.Name;
            puppy.Breed = updatePuppyRequestDto.Breed;
            puppy.BirthDate = updatePuppyRequestDto.BirthDate;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeletePuppyById(Guid id)
        {
            var puppy = await _dbContext.Puppies.FindAsync(id);
            if (puppy==null)
               throw new Exception("No Record Found");
              _dbContext.Remove(puppy);
            await _dbContext.SaveChangesAsync();
        }
    }
}
