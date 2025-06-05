using ASP.NETWebApp.Models;
using ASP.NETWebApp.DTO.Character;
using AutoMapper;

namespace ASP.NETWebApp
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
            CreateMap<UpdateCharacterDTO, Character>();
            
        }
    }
}
