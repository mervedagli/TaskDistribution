using Microsoft.AspNetCore.Mvc;
using TaskDistribution.Repositories;

namespace TaskDistribution.Controllers
{
    public class TaskController : Controller
    {
        private ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [Route("/Task/Index")]
        public async Task<IActionResult> Index()
        {
            var tasks=await _taskRepository.TList("TaskDifficultType","User");
            return View(tasks);
        }
        [HttpGet]
        public async Task<IActionResult> TaskAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TaskAdd(TaskDistribution.Data.Modals.Task task)
        {
            await _taskRepository.Add(task);
            return RedirectToAction("Index");  
        }
    }
}
