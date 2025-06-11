using System.ComponentModel.DataAnnotations;

namespace UserManagementSystem.DTOS.UsersDTO
{
    /// <summary>
    /// Class of Add User Dto
    /// exluding Id.
    /// excluding Id.
    /// </summary>
    public class AddUserDto
    {

        public string Name { get; set; } = "";
        public int Age { get; set; } = 0;
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
