using Microsoft.AspNetCore.Mvc;

namespace CRUDStudent.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
