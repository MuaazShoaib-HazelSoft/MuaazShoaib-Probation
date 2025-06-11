using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.DTOS.UsersDTO;
using UserManagementSystem.Models;
using UserManagementSystem.Services.UserService;
using UserManagementSystem.Utils;

namespace UserManagement.Controllers
{
    /// <summary>
    /// Controller to handle all user-related operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        [HttpGet("getallusers")]
        public IActionResult GetAllUsers()
        {
            // Validate ModelState if any query/body params exist
            var validationResult = RequestValidator.ValidateRequest(ModelState);
            if (validationResult != null) return validationResult;

            var response = _userService.GetAllUsers();
            return StatusCode(response.statusCode, response);
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        [HttpGet("getuserbyid/{Id?}")]
        public IActionResult GetUserById(int Id)
        {
            var validationResult = RequestValidator.ValidateRequest(ModelState);
            if (validationResult != null) return validationResult;
            if (Id == 0)
            {
                var apiResponse = new ApiResponse<string>
                (
                   null, "Id is required in the route", 400, false
                );
                return BadRequest(apiResponse);
            }
            var response = _userService.GetUserById(Id);
            return StatusCode(response.statusCode, response);
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        [HttpPost("adduser")]
        public IActionResult AddUser([FromBody] AddUserDto newUser)
        {
            var validationResult = RequestValidator.ValidateRequest(ModelState);
            if (validationResult != null) return validationResult;

            var serviceResponse = _userService.AddUser(newUser);
            return StatusCode(serviceResponse.statusCode, serviceResponse);
        }

        /// <summary>
        /// Updates an existing user's details.
        /// </summary>
        [HttpPut("updateuserdetails/{Id}")]
        public IActionResult UpdateUserDetails(int Id, [FromBody] UpdateUserDto updatedUser)
        {
            var validationResult = RequestValidator.ValidateRequest(ModelState);
            if (validationResult != null) return validationResult;

            if (Id <= 0)
            {
                var apiResponse = new ApiResponse<string>(
                    null, "Valid user Id must be provided.", 400, false
                );
                return BadRequest(apiResponse);
            }

            var response = _userService.UpdateUser(Id, updatedUser);
            return StatusCode(response.statusCode, response);
        }

        /// <summary>
        /// Deletes a user by their name and email.
        /// </summary>
        [HttpDelete("deleteuser")]
        public IActionResult DeleteUser([FromBody] User userToDelete)
        {
            var validationResult = RequestValidator.ValidateRequest(ModelState);
            if (validationResult != null) return validationResult;

            var response = _userService.DeleteUser(userToDelete);
            return StatusCode(response.statusCode, response);
        }
    }
}
