using ASP.NETWebApp.DTO.Character;
using ASP.NETWebApp.Models;
using AutoMapper;
using System.Linq;

namespace ASP.NETWebApp.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> s_charactersList = new List<Character>
        {
            new Character{Id = 1, Name = "Muaaz", Description = "Good Student", Type ="Knight"},
            new Character { Id = 2, Name = "Thanos", Description = "Mad Titan", Type = "Villain" },
            new Character { Id = 3, Name = "Iron Man", Description = "Avengers", Type = "Hero" }
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<string>> AddCharacter(AddCharacterDTO newCharacter)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                Character character = _mapper.Map<Character>(newCharacter);
                character.Id = s_charactersList.Max(c => c.Id) + 1;
                s_charactersList.Add(character);
                response.Message = "Character Added Succesfully";
                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;  
                response.Success = false;
                response.httpCode = 404;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDTO>> serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            serviceResponse.Data = _mapper.Map<List<GetCharacterDTO>>(s_charactersList); 
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetCharacterDTO>> GetFirstCharacter()
        {
            ServiceResponse<GetCharacterDTO> serviceResponse = new ServiceResponse<GetCharacterDTO>();
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(s_charactersList[0]);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDTO> serviceResponse = new ServiceResponse<GetCharacterDTO>();
            serviceResponse.Data = _mapper.Map <GetCharacterDTO>(s_charactersList.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }
        public async Task<ServiceResponse<string>> UpdateCharacter(UpdateCharacterDTO newCharacter)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();
            try
            {
                Character existingCharacter = s_charactersList.FirstOrDefault(c => c.Id == newCharacter.Id);
                if (existingCharacter == null)
                {
                    serviceResponse.Message = $"Character with Id {newCharacter.Id} not found.";
                    serviceResponse.Success = false;
                    serviceResponse.httpCode = 404;
                    return serviceResponse;
                }
                _mapper.Map(newCharacter, existingCharacter);
                serviceResponse.Success = true;
                serviceResponse.httpCode = 200;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                serviceResponse.httpCode = 404;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> DeleteCharacter(int Id)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();
            try
            {
           
                Character deleteCharacter = s_charactersList.First(c => c.Id == Id);
                if (deleteCharacter == null)
                {
                    serviceResponse.Message = $"Character with Id {deleteCharacter.Id} not found.";
                    serviceResponse.Success = false;
                    serviceResponse.httpCode = 404;
                    return serviceResponse;
                }
                s_charactersList.Remove(deleteCharacter);
                
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
                serviceResponse.httpCode = 404;

            }
            return serviceResponse;
        }
    }
}
