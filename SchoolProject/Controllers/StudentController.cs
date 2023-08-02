using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.DTO.Students;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        IMapper _mapper;
        public StudentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentDTO createStudentdto)
        {
            var student = _mapper.Map<Student>(createStudentdto);
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            students = _context.Students.ToList();
            return Ok(students);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            return Ok(student);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDTO updateStudent)
        {
            if (updateStudent == null || id != updateStudent.Id)
            {
                return BadRequest("Invalid request");
            }
            var student = _mapper.Map<Student>(updateStudent);
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
