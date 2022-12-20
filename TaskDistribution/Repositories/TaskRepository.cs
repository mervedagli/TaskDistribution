using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using TaskDistribution.Data.Modals;

namespace TaskDistribution.Repositories
{
    public class TaskRepository:GenericRepository<TaskDistribution.Data.Modals.Task>,ITaskRepository
    {
        private readonly TaskDistributionContext _dbContext;
        public TaskRepository(TaskDistributionContext dbContext):base(dbContext)
        {
            _dbContext = dbContext; 
        }

        public async  Task<IEnumerable<TaskDistribution.Data.Modals.Task>> Assignment()
        {
            // METOD HENÜZ BİTMEDİ DEVAM EDİYORUM.

            var assignmentList = _dbContext.Tasks.Where(x => x.User.UserRoleID == 2).ToList();
            var nonAssignmentList = _dbContext.Tasks.Where(x => x.UserID == null).ToList();
            var developerList = _dbContext.Users.Where(x => x.UserRoleID == 2).ToList();

            var nonAssignmentListGroupbyTaskType = nonAssignmentList.GroupBy(x => x.TaskTypeID).Select(a => new
            {
                typeId = a.Key,
                difficultDesc = a.OrderByDescending(x => x.TaskDifficultTypeID).ToList(),

            }).ToList();

            var assignmentListGroupbyDeveloper = assignmentList.GroupBy(x => x.UserID).Select(a => new
            {
                userId = a.Key,
                sum = a.Sum(x => x.TaskDifficultTypeID),
                tasks = a.Select(x => x.TaskTypeID).ToList()

            }).ToList().OrderBy(x => x.sum).ToList();


            if (assignmentListGroupbyDeveloper.Count() == 0)
            {
                var a = 0;
                foreach (var item in nonAssignmentListGroupbyTaskType)
                {
                    var firstHarderTtask = item.difficultDesc.First();
                    if (firstHarderTtask.UserID == null)
                    {
                        firstHarderTtask.UserID = developerList[a].UserId;
                        await Update(firstHarderTtask);
                        a += 1;
                    }
                }


            }
            else if (assignmentListGroupbyDeveloper.Count() != developerList.Count())
            {
                var a = 0;
                foreach (var dev in developerList)
                {

                    if (assignmentListGroupbyDeveloper.Where(x => x.userId == dev.UserId).FirstOrDefault() == null)
                    {

                        var firstHarderTtask = nonAssignmentListGroupbyTaskType[a].difficultDesc.First();
                        if (firstHarderTtask.UserID == null)
                        {
                            firstHarderTtask.UserID = dev.UserId;
                            await Update(firstHarderTtask);
                            a += 1;
                        }

                    }


                }


            }
            else
            {

            }

            // burdan sonrası pek doğru çalışmıyor
            nonAssignmentList = _dbContext.Tasks.Where(x => x.UserID == null).ToList();

            if (nonAssignmentList.Any())
            {
                assignmentList = _dbContext.Tasks.Where(x => x.User.UserRoleID == 2).ToList();

                developerList = _dbContext.Users.Where(x => x.UserRoleID == 2).ToList();

                nonAssignmentListGroupbyTaskType = nonAssignmentList.GroupBy(x => x.TaskTypeID).Select(a => new
                {
                    typeId = a.Key,
                    difficultDesc = a.OrderByDescending(x => x.TaskDifficultTypeID).ToList(),

                }).ToList();

                assignmentListGroupbyDeveloper = assignmentList.GroupBy(x => x.UserID).Select(a => new
                {
                    userId = a.Key,
                    sum = a.Sum(x => x.TaskDifficultTypeID),
                    tasks = a.Select(x => x.TaskTypeID).ToList()
                }).ToList().OrderBy(x => x.sum).ToList();

                foreach (var item in nonAssignmentListGroupbyTaskType)
                {
                    foreach (var task in item.difficultDesc)
                    {
                        var list = new List<KeyValuePair<int?, int>>();

                        foreach (var developer in assignmentListGroupbyDeveloper)
                        {
                            //var developer = assignmentListGroupbyDeveloper.Where(x => x.userId == dev.UserId).FirstOrDefault();


                            if (!developer.tasks.Contains(item.typeId))
                            {
                                task.UserID = developer.userId;
                                await Update(task);
                                developer.tasks.Add(item.typeId);
                                // developer a ata, task listesinden atandı diye işaretle

                            }
                            else
                            {

                                var taskTypeCount = developer.tasks.Count(x => x == item.typeId);
                                var pairList = new KeyValuePair<int?, int>(developer.userId, taskTypeCount);
                                list.Add(pairList);
                            }
                        }


                        if (task.UserID == null)
                        {
                            var userID = list.OrderBy(x => x.Value).FirstOrDefault().Key;
                            task.UserID = userID;
                            await Update(task);
                            assignmentListGroupbyDeveloper.Where(x => x.userId == userID).FirstOrDefault().tasks.Add(item.typeId);

                        }

                    }
                }
            }

            return assignmentList;

        }

    }
}
