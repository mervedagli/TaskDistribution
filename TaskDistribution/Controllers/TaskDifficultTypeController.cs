using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskDistribution.Repositories;

namespace TaskDistribution.Controllers
{
    public class TaskDifficultTypeController : Controller
    {
        private ITaskDifficultTypeRepository _taskDifficultTypeRepository;

        public TaskDifficultTypeController(ITaskDifficultTypeRepository taskDifficultTypeRepository)
        {
            _taskDifficultTypeRepository = taskDifficultTypeRepository;
        }
        [Route("/TaskDifficultType/Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.sessionRole = HttpContext.Session.GetString("username");
            if (ViewBag.sessionRole == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var taskDifficultTypes=await _taskDifficultTypeRepository.GetAll();
            return View(taskDifficultTypes);
        }
    }
}
