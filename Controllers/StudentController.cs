using CRUDStudent.Data;
using CRUDStudent.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using MVCFirst.Controllers;

namespace CRUDStudent.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            var student_add = new Student
            {
                Name = student.Name,
                Major = student.Major,
                dob = student.dob
            };
            await dbContext.Students.AddAsync(student_add);
            await dbContext.SaveChangesAsync();
            return View();
        }
    }
}
