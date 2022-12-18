using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskDistribution.Repositories;

namespace TaskDistribution.Controllers
{
    //[Route("/[controller]/[action]")]
    public class TaskController : Controller
    {
        private ITaskRepository _taskRepository;
        private ITaskDifficultTypeRepository _taskDifficultTypeRepository;

        public TaskController(ITaskRepository taskRepository, ITaskDifficultTypeRepository taskDifficultTypeRepository)
        {
            _taskRepository = taskRepository;
            _taskDifficultTypeRepository = taskDifficultTypeRepository;
        }
        //[AllowAnonymous]
        [Route("Task/Index")]
        public async Task<IActionResult> Index()
        {
            var tasks=(await _taskRepository.TList("TaskDifficultType","User")).Where(x=>x.IsDeleted_FL==false).ToList();
            ViewBag.sessionRole = HttpContext.Session.GetString("username");
            if (ViewBag.sessionRole==null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(tasks);
        }

        [HttpGet]
        public async Task<IActionResult> TaskAdd()
        {
            var taskDifficultTypeList =(await _taskDifficultTypeRepository.GetAll());
            List<SelectListItem> taskDifficultTypeListItem= (from x in taskDifficultTypeList
                                                             select new SelectListItem
                                                             {
                                                                 Text=x.TaskDifficultType_NM,
                                                                 Value=x.TaskDifficultTypeID.ToString(),
                                                             }).ToList();
            ViewBag.TaskDifficultTypeList = taskDifficultTypeListItem;
            ViewBag.sessionRole = HttpContext.Session.GetString("username");
            if (ViewBag.sessionRole == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TaskAdd(TaskDistribution.Data.Modals.Task task)
        {
            if (!ModelState.IsValid)
            {
                return View("TaskAdd");
            }
            await _taskRepository.Add(task);

            return RedirectToAction("Index");  
        }

        [Route("/Task/TaskDelete/{id}")]
        public async Task<IActionResult> TaskDelete(int id)
        {
            var task=await _taskRepository.Find(id);
            task.IsDeleted_FL = true;
            await _taskRepository.Update(task);
            return RedirectToAction("Index");  
        }
        [Route("/Task/TaskGetById/{id}")]
        public async Task<IActionResult> TaskGetById(int id)
        {

            var taskDifficultTypeList = (await _taskDifficultTypeRepository.GetAll());
            List<SelectListItem> taskDifficultTypeListItem = (from x in taskDifficultTypeList
                                                              select new SelectListItem
                                                              {
                                                                  Text = x.TaskDifficultType_NM,
                                                                  Value = x.TaskDifficultTypeID.ToString(),
                                                              }).ToList();
            ViewBag.TaskDifficultTypeList = taskDifficultTypeListItem;

            var task = await _taskRepository.Find(id);
            ViewBag.sessionRole = HttpContext.Session.GetString("username");
            if (ViewBag.sessionRole == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> TaskUpdate(TaskDistribution.Data.Modals.Task task)
        {
            if (!ModelState.IsValid)
            {
                return View("TaskUpdate");
            }
            await _taskRepository.Update(task);
            return RedirectToAction("Index");
        }

    }
}
