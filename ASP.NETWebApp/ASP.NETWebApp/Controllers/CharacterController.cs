using Microsoft.AspNetCore.Mvc;
using ASP.NETWebApp.Models;
using ASP.NETWebApp.Services.CharacterService;
namespace ASP.NETWebApp.Controllers
  
{
    // To get all the api features. 
    [ApiController]
    // To check the controller name
    [Route("[controller]")]
    /// </summary> Character class Controller defined to add,update,delete 
    /// values in the list and fetch them all or single by the defined routes.
    public class CharacterController:ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        private static List<Character> s_charactersList = new List<Character>
        {
            new Character{Id = 1, Name = "Muaaz", Description = "Good Student", Type ="Knight"},
            new Character { Id = 2, Name = "Thanos", Description = "Mad Titan", Type = "Villain" },
            new Character { Id = 3, Name = "Iron Man", Description = "Avengers", Type = "Hero" }
        };
        // Route to get all characters
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(_characterService.GetAllCharacters());
        }
        // Route to get first character.
        [HttpGet("GetFirstCharacter")]
        public async Task<IActionResult> GetFirst()
        {
            return Ok( await _characterService.GetFirstCharacter());
        }
        // Route to get character by id parameter.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int Id)
        {
            return Ok(await _characterService.GetCharacterById(Id));
        }
        // Add a new character through Post Man in 
        // the list.
        [HttpPost("addCharacter")]
        public async Task<IActionResult> AddCharacter(Character newCharacter)
        {
            try
            {
                await _characterService.AddCharacter(newCharacter);
                return Ok("Character Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error Occured:{ ex.Message}");
            }
        }
        // Update the  character through Post Man in 
        // the list.
        [HttpPut("updateCharacter")]
        public async Task<IActionResult> UpdateCharacter(Character newCharacter)
        {
            try
            {
                Character updatedCharacter = s_charactersList.First(c => c.Id == newCharacter.Id);
                updatedCharacter.Id = newCharacter.Id;
                updatedCharacter.Name = newCharacter.Name;
                updatedCharacter.Description = newCharacter.Description;
                updatedCharacter.Type = newCharacter.Type;
                return Ok("Character Updated Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }   
        }
        // Update the  character through Post Man in 
        // the list.
        [HttpDelete("deleteCharacter")]
        public async Task <IActionResult> DeleteCharacter(Character newCharacter)
        {
            try
            {
                Character deleteCharacter = s_charactersList.First(c => c.Id == newCharacter.Id);
                s_charactersList.Remove(deleteCharacter);
                return Ok("Character Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
