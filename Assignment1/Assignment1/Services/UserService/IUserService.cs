using UserManagementSystem.Models;

namespace UserManagementSystem.Services.UserService
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int Id);
        void AddUser(User newUser);
        void UpdateUser(int Id, User updatedUser);
        void DeleteUser(User userToDelete);

    }
}
