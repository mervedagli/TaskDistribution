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
        private ITaskTypeRepository _taskTypeRepository;

        public TaskController(ITaskRepository taskRepository, ITaskDifficultTypeRepository taskDifficultTypeRepository, ITaskTypeRepository taskTypeRepository)
        {
            _taskRepository = taskRepository;
            _taskDifficultTypeRepository = taskDifficultTypeRepository;
            _taskTypeRepository = taskTypeRepository;
        }
        //[AllowAnonymous]
        [Route("Task/Index")]
        public async Task<IActionResult> Index()
        {
            var tasks=(await _taskRepository.TList("TaskDifficultType","User","TaskType")).Where(x=>x.IsDeleted_FL==false).ToList();
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

            var taskTypeList = (await _taskTypeRepository.GetAll());
            List<SelectListItem> taskTypeListItem = (from x in taskTypeList
                                                              select new SelectListItem
                                                              {
                                                                  Text = x.TaskType_NM,
                                                                  Value = x.TaskTypeID.ToString(),
                                                              }).ToList();
            ViewBag.TaskTypeList = taskTypeListItem;

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

            var taskTypeList = (await _taskTypeRepository.GetAll());
            List<SelectListItem> taskTypeListItem = (from x in taskTypeList
                                                     select new SelectListItem
                                                     {
                                                         Text = x.TaskType_NM,
                                                         Value = x.TaskTypeID.ToString(),
                                                     }).ToList();
            ViewBag.TaskTypeList = taskTypeListItem;

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

        [HttpGet]
        [Route("Task/TaskAssignment")]
        public async Task<IActionResult> TaskAssignment()
        {

            var x=await _taskRepository.Assignment();
            return View();
        }

    }
}
