using System.Text.RegularExpressions;
using UserManagementSystem.DTOS.UsersDTO;
using UserManagementSystem.Models;
using AutoMapper;

namespace UserManagementSystem.Services.UserService
{
    /// <summary>
    /// Implementation of All
    /// Users Methods.
    /// </summary>
    public class UserService : IUserService
    {
        
        private static readonly List<User> s_usersList = new List<User>();

        private readonly IMapper _userMapper;

        // Compiled email regex for better performance
        private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public UserService(IMapper mapper)
        {
            _userMapper = mapper;
        }

        // Helper method to validate email.
        private bool IsValidEmail(string email) =>
            !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email);

        // Helper method to validate user fields.
        private bool IsValidUserFields(string name, string email, string password, int age) =>
            !string.IsNullOrWhiteSpace(name) &&
            !string.IsNullOrWhiteSpace(email) &&
            !string.IsNullOrWhiteSpace(password) &&
            age > 0 && age <= 100;

        // Add new user.
        public ApiResponse<AddUserDto> AddUser(AddUserDto newUser)
        {
            if (!IsValidUserFields(newUser.Name, newUser.Email, newUser.Password, newUser.Age))
            {
                return new ApiResponse<AddUserDto>(
                    null, "Name, Email, Password, and a valid Age (1-100) are required", 400, false);
            }

            if (newUser.Age < 18)
            {
                return new ApiResponse<AddUserDto>(
                    null, "Age must be at least 18", 400, false);
            }
            if (newUser.Password.Length < 5)
            {
                return new ApiResponse<AddUserDto>(
                    null, "Password must be of at least 5 digits", 404, false);
            }
            if (!IsValidEmail(newUser.Email))
            {
                return new ApiResponse<AddUserDto>(
                    null, "Invalid email format", 400, false);
            }

            if (s_usersList.Any(u => u.Email == newUser.Email))
            {
                return new ApiResponse<AddUserDto>(
                    null, "User with this email already exists", 400, false);
            }

            var addUser = _userMapper.Map<User>(newUser);
            addUser.Id = s_usersList.Any() ? s_usersList.Max(u => u.Id) + 1 : 1;

            s_usersList.Add(addUser);

            return new ApiResponse<AddUserDto>(
                newUser, "User added successfully", 200, true);
        }

        // Delete a user by name and email.
        public ApiResponse<List<GetUsersDto>> DeleteUser(User userToDelete)
        {
            if (string.IsNullOrWhiteSpace(userToDelete.Name) || string.IsNullOrWhiteSpace(userToDelete.Email))
            {
                return new ApiResponse<List<GetUsersDto>>(
                    null, "Name and Email are required for deletion", 400, false);
            }

            var existingUser = s_usersList.FirstOrDefault(u =>
                u.Name == userToDelete.Name && u.Email == userToDelete.Email);

            if (existingUser == null)
            {
                return new ApiResponse<List<GetUsersDto>>(
                    null, "User not found with provided name and email", 404, false);
            }

            s_usersList.Remove(existingUser);

            return new ApiResponse<List<GetUsersDto>>(
                    _userMapper.Map<List<GetUsersDto>>(s_usersList), "User deleted successfully", 200, true);
        }

        // Get all users.
        public ApiResponse<List<GetUsersDto>> GetAllUsers()
        {
            if (!s_usersList.Any())
            {
                return new ApiResponse<List<GetUsersDto>>(
                    null, "No users registered at this moment.", 404, false);
            }

            return new ApiResponse<List<GetUsersDto>>(
                _userMapper.Map<List<GetUsersDto>>(s_usersList), "Users fetched successfully", 200, true);
        }

        // Get a single user by ID.
        public ApiResponse<GetUsersDto> GetUserById(int id)
        {
            var user = s_usersList.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return new ApiResponse<GetUsersDto>(
                    null, $"No user found with Id = {id}", 404, false);
            }

            return new ApiResponse<GetUsersDto>(
                _userMapper.Map<GetUsersDto>(user), "User fetched successfully", 200, true);
        }

        // Update an existing user by ID.
        public ApiResponse<UpdateUserDto> UpdateUser(int id, UpdateUserDto updatedUser)
        {
            if (!IsValidUserFields(updatedUser.Name, updatedUser.Email, updatedUser.Password, updatedUser.Age))
            {
                return new ApiResponse<UpdateUserDto>(
                    null, "Name, Email, Password, and valid Age (1-100) are required", 400, false);
            }

            if (!IsValidEmail(updatedUser.Email))
            {
                return new ApiResponse<UpdateUserDto>(
                    null, "Invalid email format", 400, false);
            }

            var existingUser = s_usersList.FirstOrDefault(u => u.Id == id);

            if (existingUser == null)
            {
                return new ApiResponse<UpdateUserDto>(
                    null, $"User with Id = {id} not found", 404, false);
            }

            // Prevent updating to an email that another user already has.
            bool emailExists = s_usersList.Any(u => u.Email == updatedUser.Email && u.Id != id);

            if (emailExists)
            {
                return new ApiResponse<UpdateUserDto>(
                    null, "Another user with this email already exists", 400, false);
            }

            // Map updated fields onto existing user.
            _userMapper.Map(updatedUser, existingUser);

            return new ApiResponse<UpdateUserDto>(
                updatedUser, "User data updated successfully", 200, true);
        }
    }
}
