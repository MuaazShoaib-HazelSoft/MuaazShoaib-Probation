using ASP.NETWebApp.Models;
using ASP.NETWebApp.DTO.Character;
using AutoMapper;
using ASP.NETWebApp.DTO.Student;

namespace ASP.NETWebApp
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
            CreateMap<UpdateCharacterDTO, Character>();
            CreateMap<Student, GetStudentDTO>();
            CreateMap<AddStudentDTO, Student>();
            CreateMap<UpdateStudentDTO, Student>();
        }
    }
}
