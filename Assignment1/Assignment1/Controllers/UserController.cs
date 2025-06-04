using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Assignment1.Controllers
{
    // Contains all the Features of Api.
    [ApiController]
    // Route for Controller Defined.
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // Users List.
        private static List<User> s_usersList = new List<User>();
        // Route to get all Users.
        [HttpGet("getallusers")]
        // Method to get all the users from Api
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(s_usersList);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error Occured : {ex.Message}");
            }
        }
        // Route to get user by id parameter.
        [HttpGet("getuser/{id}")]
        // Method to get all the users with Id from Api.
        public IActionResult GetUserByID(int Id)
        {
            try
            {
                User user = s_usersList.FirstOrDefault(c => c.Id == Id);
                if (user == null)
                {
                    return NotFound($"No user found with ID = {Id}");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
        // Add a new User through Post Man in 
        // the List.
        [HttpPost("adduser")]
        // Method to add all the users from Api.
        public IActionResult AddUsers(User newUser)
        {
            try
            {
               
                User findUser = s_usersList.FirstOrDefault(c => c.Id == newUser.Id || c.Email == newUser.Email);
                if (findUser != null)
                {
                    return BadRequest("User of this Id or Email already Exists");
                }
                s_usersList.Add(newUser);
                return Ok("User Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error Occured:{ex.Message}");
            }
        }
        // Update the User through Post Man in 
        // the list.
        [HttpPut("updateuser/{id}")]
        public IActionResult UpdateUserDetails(int Id,User newUser)
        {
            try
            {
                User findUser = s_usersList.First(c => c.Id == Id || c.Email == newUser.Email);
                if (findUser != null)
                {
                    return BadRequest("User of this Id or Email already Exists");
                }
                User updatedUser = s_usersList.First(c => c.Id == Id);
                updatedUser.Id = newUser.Id;
                updatedUser.Name = newUser.Name;
                updatedUser.Email = newUser.Email;
                updatedUser.Password = newUser.Password;
                updatedUser.Age = newUser.Age;
                return Ok("User Updated Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
        // Delete the  character through Post Man in 
        // the list.
        [HttpDelete("deleteUser")]
        public IActionResult DeleteUser(User newUser)
        {
            try
            {
                User deleteUser = s_usersList.First(c => c.Id == newUser.Id);
                s_usersList.Remove(deleteUser);
                return Ok("User Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}



