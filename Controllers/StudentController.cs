using CRUDStudent.Data;
using CRUDStudent.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        //Student Add(View + Function)
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

        //Student get all data
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        //Edit page
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            var student_edit =  await dbContext.Students.FindAsync(student.Id);

            //Edit value
            if(student_edit != null)
            {
                student_edit.Name = student.Name;
                student_edit.Major = student.Major;
                student_edit.dob = student.dob;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List","Student");
        }

        //Delete 
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student_delete = await dbContext.Students.FindAsync(id);
            if (student_delete == null)
                return NotFound();
            dbContext.Remove(student_delete);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Student");
        }
    }
}
