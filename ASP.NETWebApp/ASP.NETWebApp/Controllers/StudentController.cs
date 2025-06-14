using ASP.NETWebApp.DTO.Character;
using ASP.NETWebApp.DTO.Student;
using ASP.NETWebApp.Models;
using ASP.NETWebApp.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Route to get all characters
        [HttpGet("getallstudents")]
        public async Task<IActionResult> GetAllStudents()
        {

            return Ok(await _studentService.getallStudents());
        }

        // Route to get students by id parameter.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int Id)
        {
            return Ok(await _studentService.getStudentById(Id));
        }
        // Add a new character through Post Man in 
        // the list.
        [HttpPost("addstudent")]
        public async Task<IActionResult> AddStudens(AddStudentDTO newStudent)
        {
            try
            {
                var serviceResponse = await _studentService.addStudent(newStudent);
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error Occured:{ex.Message}");
            }
        }
        // Update the  character through Post Man in 
        // the list.
        [HttpPut("updatestudent/{id}")]
        public async Task<IActionResult> UpdateStudent(int Id,UpdateStudentDTO updatedStudent)
        {
            return Ok(await _studentService.updateStudent(Id,updatedStudent));

        }
        // Update the  character through Post Man in 
        // the list.
        [HttpDelete("deletestudent")]
        public async Task<IActionResult> DeleteStudent(Student studentToDelete)
        {
            return Ok(await _studentService.deleteStudent(studentToDelete));
        }
    }
}

