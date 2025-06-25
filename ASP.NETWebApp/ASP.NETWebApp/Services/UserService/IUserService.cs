using ASP.NETWebApp.DTO.Character;
using ASP.NETWebApp.DTO.User;
using ASP.NETWebApp.Models;

namespace ASP.NETWebApp.Services.UserService
{
    public interface IUserService
    {
        Task<List<GetCharacterDTO>> allCharacters(UsersQueryParameters query);
        public IQueryable<Character> asQueryable();
    }
}
