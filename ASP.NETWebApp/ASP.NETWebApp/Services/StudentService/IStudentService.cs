using ASP.NETWebApp.DTO.Student;
using ASP.NETWebApp.Models;

namespace ASP.NETWebApp.Services.UserService
{
    public interface IStudentService
    {
        Task<ServiceResponse<AddStudentDTO>> addStudent(AddStudentDTO studentDTO);
        Task<ServiceResponse<UpdateStudentDTO>> updateStudent(int Id,UpdateStudentDTO studentDTO);
        Task<ServiceResponse<List<GetStudentDTO>>> getallStudents();
        Task<ServiceResponse<GetStudentDTO>> getStudentById(int Id);
        Task<ServiceResponse<List<GetStudentDTO>>> deleteStudent(Student studentToDelete);
    }
}
