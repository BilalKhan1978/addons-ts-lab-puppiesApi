using addons_ts_lab_puppiesApi.Services;
using addons_ts_lab_puppiesApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace addons_ts_lab_puppiesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuppyController : Controller
    {
        private readonly IPuppyService _puppyService;
        public PuppyController(IPuppyService puppyService)
        {
            _puppyService = puppyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPuppies()
        {
            try
            {
                return Ok(await _puppyService.GetAllPuppies());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOnePuppy([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _puppyService.GetPuppyById(id));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    
        [HttpPost]
        public async Task<IActionResult> AddPuppy([FromBody] AddPuppyRequestDto addPuppyRequestDto)
        {
            try
            {
                var addPuppy = await _puppyService.AddPuppy(addPuppyRequestDto);
                return Ok(addPuppy);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
   
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePuppy([FromRoute] Guid id, UpdatePuppyRequestDto updatePuppyRequestDto)
        {
            try
            {
                await _puppyService.UpdatePuppy(id, updatePuppyRequestDto);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuppy([FromRoute] Guid id)
        {
            try
            {
                await _puppyService.DeletePuppyById(id);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

