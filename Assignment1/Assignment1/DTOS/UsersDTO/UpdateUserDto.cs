using System.ComponentModel.DataAnnotations;

namespace UserManagementSystem.DTOS.UsersDTO
{
    /// <summary>
    /// Class of Update User Dto 
    /// excluding Id.
    /// </summary>
    public class UpdateUserDto
    {
        public string Name { get; set; } = "";
        public int Age { get; set; } = 0;
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
