using ASP.NETWebApp.DTO.Character;
using ASP.NETWebApp.Models;
namespace ASP.NETWebApp.Services.CharacterService

{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponse<string>> AddCharacter(AddCharacterDTO newCharacter);
        Task <ServiceResponse<GetCharacterDTO>>  GetFirstCharacter();
        Task<ServiceResponse<string>> UpdateCharacter(UpdateCharacterDTO newCharacter);
        Task<ServiceResponse<string>> DeleteCharacter(int Id);

    }
}
