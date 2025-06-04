using ASP.NETWebApp.Models;
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
        public async Task AddCharacter(Character newCharacter)
        {
            try
            {
                s_charactersList.Add(newCharacter);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add character", ex);
            }
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return s_charactersList;
        }
        public async Task<Character> GetFirstCharacter()
        {
            return s_charactersList[0];
        }

        public async Task<Character> GetCharacterById(int id)
        {
            return s_charactersList.FirstOrDefault(c => c.Id == id);
        }
    }
}
