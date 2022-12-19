using Microsoft.AspNetCore.Mvc;
using TaskDistribution.Repositories;

namespace TaskDistribution.Controllers
{
    public class TaskTypeController : Controller
    {
        private readonly ITaskTypeRepository _taskTypeRepository;

        public TaskTypeController(ITaskTypeRepository taskTypeRepository)
        {
            _taskTypeRepository = taskTypeRepository;
        }
        [Route("/TaskType/Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.sessionRole = HttpContext.Session.GetString("username");
            if (ViewBag.sessionRole == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var taskTypes = await _taskTypeRepository.GetAll();
            return View(taskTypes);
        }
    }
}
