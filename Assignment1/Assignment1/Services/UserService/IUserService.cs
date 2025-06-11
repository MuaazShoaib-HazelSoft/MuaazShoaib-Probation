using UserManagementSystem.DTOS.UsersDTO;
using UserManagementSystem.Models;

namespace UserManagementSystem.Services.UserService
{
    /// <summary>
    /// Interface having all
    /// methods of Users.
    /// </summary>
    public interface IUserService
    {
        ApiResponse<List<GetUsersDto>> GetAllUsers();
        ApiResponse<GetUsersDto> GetUserById(int Id);
        ApiResponse<AddUserDto> AddUser(AddUserDto newUser);
        ApiResponse<UpdateUserDto> UpdateUser(int Id, UpdateUserDto updatedUser);
        ApiResponse<List<GetUsersDto>> DeleteUser(User userToDelete);

    }
}
