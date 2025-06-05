using UserManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Services.UserService;


namespace UserManagement.Controllers
{
    /// <summary>
    /// API Controller for managing Users.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // In-memory list to store users
        private static readonly List<User> s_usersList = new List<User>();
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Gets all registered users.
        /// </summary>
        [HttpGet("getallusers")]
        public IActionResult GetAllUsers()
        {
           
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a user by their Id.
        /// </summary>
        [HttpGet("getuserbyid/{id}")]
        public IActionResult GetUserById(int Id)
        {
            try
            {
                return Ok(_userService.GetUserById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        [HttpPost("adduser")]
        public IActionResult AddUser(User newUser)
        {
            try
            {
                _userService.AddUser(newUser);
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing user's details.
        /// </summary>
        [HttpPut("updateuserdetails/{id}")]
        public IActionResult UpdateUserDetails(int Id, User updatedUser)
        {
            try
            {
                _userService.UpdateUser(Id, updatedUser);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a user by Name and Email.
        /// </summary>
        [HttpDelete("deleteuser")]
        public IActionResult DeleteUser(User userToDelete)
        {
          
            try
            {
                _userService.DeleteUser(userToDelete);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
