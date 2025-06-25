using ASP.NETWebApp.Data;
using ASP.NETWebApp.DTO.Character;
using ASP.NETWebApp.DTO.User;
using ASP.NETWebApp.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETWebApp.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserService(DataContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<GetCharacterDTO>> allCharacters(UsersQueryParameters query)
        {
            var charactersQuery = asQueryable();
            if (!string.IsNullOrEmpty(query.SearchItem))
            {
                charactersQuery = charactersQuery.Where(c=> c.Name.Contains(query.SearchItem) || c.Description.Contains(query.SearchItem));
            }
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.isDescending)
                {
                    charactersQuery = charactersQuery.OrderByDescending(e => EF.Property<object>(e, query.SortBy));
                }
                else
                {
                    charactersQuery = charactersQuery.OrderBy(e => EF.Property<object>(e, query.SortBy));
                }
            }
            if(query.PageNumber < 1)
            {
                query.PageNumber = 1;
            }
            var skipPages = (query.PageNumber -1) * query.PageSize;
            charactersQuery = charactersQuery.Skip(skipPages).Take(query.PageSize);
            var chList = await charactersQuery.ToListAsync();
            var list =  _mapper.Map<List<GetCharacterDTO>>(chList);
            return list;
        }

        public IQueryable<Character> asQueryable()
        {
           return _context.Characters.AsQueryable();
        }
    }
}
