using ASP.NETWebApp.Data;
using ASP.NETWebApp.DTO.Character;
using ASP.NETWebApp.DTO.Student;
using ASP.NETWebApp.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASP.NETWebApp.Services.UserService
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly DbfapproachContext _context;

        public StudentService(IMapper mapper, DbfapproachContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<AddStudentDTO>> addStudent(AddStudentDTO addStudentDto)
        {
            ServiceResponse<AddStudentDTO> serviceResponse = new ServiceResponse<AddStudentDTO>();
            try
            {
                
                Student student = _mapper.Map<Student>(addStudentDto);
                await _context.AddAsync(student);
                await _context.SaveChangesAsync();
                serviceResponse.Data = addStudentDto;
                serviceResponse.Success = true;
                serviceResponse.Message = "Student Added Successfully";
                serviceResponse.httpCode = 200;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error occured : {ex.Message}";
                serviceResponse.httpCode = 400;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDTO>>> deleteStudent(Student studentToDelete)
        {
            ServiceResponse<List<GetStudentDTO >> serviceResponse = new ServiceResponse<List<GetStudentDTO>>();
            try
            {
                Student student = await _context.Students.FirstAsync(c => c.Id == studentToDelete.Id);
                _context.Students.Remove(studentToDelete);
                await _context.SaveChangesAsync();
                List<Student> studentList = await _context.Students.ToListAsync();
                serviceResponse.Data = _mapper.Map<List<GetStudentDTO>>(studentList);
                serviceResponse.Success = true;
                serviceResponse.Message = "Student Deleted Successfully";
                serviceResponse.httpCode = 200;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error occured : {ex.Message}";
                serviceResponse.httpCode = 400;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDTO>>> getallStudents()
        {
            ServiceResponse<List<GetStudentDTO>> serviceResponse = new ServiceResponse<List<GetStudentDTO>>();
            try
            {
                List<Student> studentList = await _context.Students.ToListAsync();
                serviceResponse.Data = _mapper.Map<List<GetStudentDTO>>(studentList);
                serviceResponse.Success = true;
                serviceResponse.Message = "Student Fetched Successfully";
                serviceResponse.httpCode = 200;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error occured : {ex.Message}";
                serviceResponse.httpCode = 400;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStudentDTO>> getStudentById(int Id)
        {
            ServiceResponse<GetStudentDTO> serviceResponse = new ServiceResponse<GetStudentDTO>();
            try
            {
                Student student = await _context.Students.FirstAsync(c => c.Id == Id);
                serviceResponse.Data = _mapper.Map<GetStudentDTO>(student);
                serviceResponse.Success = true;
                serviceResponse.Message = "Student Fetched Successfully";
                serviceResponse.httpCode = 200;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error occured : {ex.Message}";
                serviceResponse.httpCode = 400;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UpdateStudentDTO>> updateStudent(int Id, UpdateStudentDTO studentDTO)
        {
            ServiceResponse<UpdateStudentDTO> serviceResponse = new ServiceResponse<UpdateStudentDTO>();
            try
            {
                Student student = await _context.Students.FirstAsync(c => c.Id == Id);
                _mapper.Map(studentDTO, student);
                await _context.SaveChangesAsync();
                serviceResponse.Data = studentDTO;
                serviceResponse.Success = true;
                serviceResponse.Message = "Student Updated Successfully";
                serviceResponse.httpCode = 200;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error occured : {ex.Message}";
                serviceResponse.httpCode = 400;
            }
            return serviceResponse;
        }
    }
}
