using ASP.NETWebApp.Data;
using ASP.NETWebApp.DTO.Character;
using ASP.NETWebApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace ASP.NETWebApp.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IMapper mapper,DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<string>> AddCharacter(AddCharacterDTO newCharacter)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                Character character = _mapper.Map<Character>(newCharacter);
                await _context.Characters.AddAsync(character);
                await _context.SaveChangesAsync();
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
            List<Character> dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetCharacterDTO>>(dbCharacters); 
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetCharacterDTO>> GetFirstCharacter()
        {
            ServiceResponse<GetCharacterDTO> serviceResponse = new ServiceResponse<GetCharacterDTO>();
            Character dbCharacter = await _context.Characters.FindAsync(1);
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            ServiceResponse<GetCharacterDTO> serviceResponse = new ServiceResponse<GetCharacterDTO>();
            Character dbCharacter = await _context.Characters.FirstAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map <GetCharacterDTO>(dbCharacter);
            return serviceResponse;
        }
        public async Task<ServiceResponse<string>> UpdateCharacter(UpdateCharacterDTO newCharacter)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();
            try
            {
                Character existingCharacter = await _context.Characters.FirstAsync(c => c.Id == newCharacter.Id);
                if (existingCharacter == null)
                {
                    serviceResponse.Message = $"Character with Id {newCharacter.Id} not found.";
                    serviceResponse.Success = false;
                    serviceResponse.httpCode = 404;
                    return serviceResponse;
                }
                _mapper.Map(newCharacter, existingCharacter);
                await _context.SaveChangesAsync();
                serviceResponse.Message = "Character Updated Successfully";
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
           
                Character deleteCharacter = await _context.Characters.FirstAsync(c => c.Id == Id);
                if (deleteCharacter == null)
                {
                    serviceResponse.Message = $"Character with Id {Id} not found.";
                    serviceResponse.Success = false;
                    serviceResponse.httpCode = 404;
                    return serviceResponse;
                }
                 _context.Characters.Remove(deleteCharacter);
                await _context.SaveChangesAsync();
                serviceResponse.Message = "Character Deleted Successfully";
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
    }
}
