using ASP.NETWebApp.Models;
namespace ASP.NETWebApp.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
        Task AddCharacter(Character newCharacter);
        Task <Character>  GetFirstCharacter();

    }
}
