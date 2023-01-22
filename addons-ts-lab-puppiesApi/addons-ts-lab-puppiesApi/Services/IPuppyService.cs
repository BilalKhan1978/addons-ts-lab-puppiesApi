using addons_ts_lab_puppiesApi.Models;
using addons_ts_lab_puppiesApi.ViewModels;

namespace addons_ts_lab_puppiesApi.Services
{
    public interface IPuppyService
    {
      Task<List<Puppy>> GetAllPuppies();
      Task<Puppy> GetPuppyById(Guid id);
      Task<Puppy> AddPuppy(AddPuppyRequestDto addPuppyRequestDto);
      Task UpdatePuppy(Guid id,UpdatePuppyRequestDto updatePuppyRequestDto);
      Task DeletePuppyById(Guid id);
      Task<List<Puppy>> FindPuppies(string Breed);
      Task<List<Puppy>> SearchPuppies(string searchCriteria);
    }
}
