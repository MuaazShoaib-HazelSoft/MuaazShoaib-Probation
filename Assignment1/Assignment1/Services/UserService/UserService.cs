using UserManagementSystem.Models;

namespace UserManagementSystem.Services.UserService
{
    public class UserService : IUserService
    {
        private static readonly List<User> s_usersList = new List<User>();
        public void AddUser(User newUser)
        {
            if (newUser == null)
            {
                throw new Exception("Users Data cannot be Empty");
            }

            if (string.IsNullOrWhiteSpace(newUser.Name) ||
                string.IsNullOrWhiteSpace(newUser.Email) ||
                string.IsNullOrWhiteSpace(newUser.Password) ||
                newUser.Age <= 0)
            {
                throw new Exception("Name,Email,Password and Age Fields are Required");
            }

            bool userExists = s_usersList.Any(u => u.Email == newUser.Email);
            if (userExists)
            {
                throw new Exception("User with this Email already Exists..");
            }

            newUser.Id = s_usersList.Count != 0 ? s_usersList.Max(u => u.Id) + 1 : 1;
            s_usersList.Add(newUser);
        }

        public void DeleteUser(User userToDelete)
        {
            if (userToDelete == null || string.IsNullOrWhiteSpace(userToDelete.Name) || string.IsNullOrWhiteSpace(userToDelete.Email))
            {
                throw new Exception("Name and Email are required for deletion.");
            }

                User existingUser = s_usersList.FirstOrDefault(u => u.Name == userToDelete.Name && u.Email == userToDelete.Email);
                if (existingUser == null)
                {
                    throw new Exception("User not found with the provided Name and Email.");
                }

                s_usersList.Remove(existingUser);
            }

        public List<User> GetAllUsers()
        {
            if (!s_usersList.Any())
            {
                throw new Exception("Users not Registered at this Moment");
            }
            return s_usersList;
        }

        public User GetUserById(int Id)
        {
            User user = s_usersList.FirstOrDefault(u => u.Id == Id);
            if (user == null)
            {
                throw new Exception($"No user found with ID = {Id}");
            }
            return user;
        }

        public void UpdateUser(int Id, User updatedUser)
        {
            User existingUser = s_usersList.FirstOrDefault(u => u.Id == Id);
            if (existingUser == null)
            {
                throw new Exception($"User with Id {Id} not found.");
            }
            if (updatedUser == null)
            {
                throw new Exception("No Field Provided..");
            }
            // Check if another user already has the same email
            bool emailExists = s_usersList.Any(u => u.Email == updatedUser.Email && u.Id != Id);
            if (emailExists)
            {
                throw new Exception("Another User with This Email Already Exists");
            }

            // Update user details
            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
            existingUser.Age = updatedUser.Age;

        }
    }
}
