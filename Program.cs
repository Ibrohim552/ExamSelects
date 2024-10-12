using System;
using CRM.DataContext;
using CRM.Entities;
using System.Linq;
using CRM.Enums;
using Task = CRM.Entities.Task;
using TaskStatus = System.Threading.Tasks.TaskStatus;

DataContext dataContext = new DataContext();

Console.Read();

//1
// var FindAllProjectThatContainsMoreThan5Task = from t in Data.Tasks
//     join p in Data.Projects on t.ProjectId equals p.ProjectId 
//     group p by p.ProjectId into g
//     where g.Count() > 5
//     select new { ProjectId = g.Key, ProjectName = g.FirstOrDefault()?.ProjectName };
//
// foreach (var project in FindAllProjectThatContainsMoreThan5Task)
// {
//     Console.WriteLine($"Project ID: {project.ProjectId}, Project Name: {project.ProjectName}");
// }


//2
// var FindTasksWithMoreThan3CommentsAndCreatedLastTwoMonths = from c in Data.Comments
//     join t in Data.Tasks on c.TaskId equals t.TaskId
//     where c.CreatedAt >= DateTime.Now.AddMonths(-2)
//     group c by t.TaskId into g
//     where g.Count() > 3
//     select new { TaskId = g.Key, TaskName = g.FirstOrDefault()?.Text };
//
// foreach (var task in FindTasksWithMoreThan3CommentsAndCreatedLastTwoMonths)
// {
//     Console.WriteLine($"Task ID: {task.TaskId}, Task Name: {task.TaskName}");
// }

//3
// var GetUsersThatCreateTheMostProjectInLastYear= from p in Data.Projects
//     join u in Data.Users on p.ManagerId equals u.UserId
//     where p.CreatedAt >= DateTime.Now.AddYears(-1)
//     group p by u.UserId into g
//     orderby g.Count() descending
//     select new { UserId = g.Key, UserName = g.FirstOrDefault()?.Manager, Count = g.Count() };
//
//
// foreach (var user in GetUsersThatCreateTheMostProjectInLastYear)
// {
//     Console.WriteLine($"User ID: {user.UserId}, User Name: {user.UserName}, Count of Projects: {user.Count}");
// }

//4




//5
// var GetProjectsThatTaskIsFinished = from t in Data.Tasks
//     join p in Data.Projects on t.ProjectId equals p.ProjectId
//     where t.Status is CRM.Enums.TaskStatus.Completed
//     group p by p.ProjectId into g
//     select new { ProjectId = g.Key, ProjectName = g.FirstOrDefault()?.ProjectName };
//
// foreach (var project in GetProjectsThatTaskIsFinished)
// {
//     Console.WriteLine($"Project ID: {project.ProjectId}, Project Name: {project.ProjectName}");
// }

//6

// var GetUsersThatDontHaveAnyProjectAndTasks= from t in Data.Tasks
//     join u in Data.Users on t.AssignedToId equals u.UserId
//     join p in Data.Projects on t.ProjectId equals p.ProjectId into gTasks
//     from p in Data.Projects.DefaultIfEmpty()
//     where p == null && gTasks.Count() == 0
//     select u;
//
// foreach (var user in GetUsersThatDontHaveAnyProjectAndTasks)
// {
//     Console.WriteLine($"User ID: {user.UserId}, User Name: {user.FirstName} {user.LastName}");
// }

//7
// var FindAllCommentsThatNotCompleted = from c in Data.Comments
//     join t in Data.Tasks on c.TaskId equals t.TaskId
//     where t.Status is not CRM.Enums.TaskStatus.Completed
//     orderby c.CreatedAt
//     select c;
//
// foreach (var comment in FindAllCommentsThatNotCompleted)
// {
//     Console.WriteLine($"Comment ID: {comment.CommentId}, Comment Text: {comment.Text}, Created At: {comment.CreatedAt}");
// }

//8 
// var GetListOfProjectsWithAvarage = from p in Data.Projects
//     join t in Data.Tasks on p.ProjectId equals t.ProjectId into gTasks
//     select new { ProjectId = p.ProjectId, ProjectName = p.ProjectName, AverageTaskCount = gTasks.Count()};
//
// foreach (var project in GetListOfProjectsWithAvarage)
// {
//     Console.WriteLine($"Project ID: {project.ProjectId}, Project Name: {project.ProjectName}, Average Task Count: {project.AverageTaskCount}");
// }

//9
// var FindUserThatHave2FInishedTask = from  t in Data.Tasks  
//     join u in Data.Users on t.AssignedToId equals u.UserId
//     join a in Data.Attachments on t.TaskId equals a.TaskId into gAttachments
//     where t.Status is CRM.Enums.TaskStatus.InProgress && gAttachments.Count() > 2
//     select u;
//
// foreach (var user in FindUserThatHave2FInishedTask)
// {
//     Console.WriteLine($"User ID: {user.UserId}, User Name: {user.FirstName} {user.LastName}");
// }

//10
var GetAllProjectThatCreatedTimeIsMoreThatFinishedTime = from p in Data.Projects 
    join t in Data.Tasks on p.ProjectId equals t.ProjectId
    orderby p.CreatedAt 
    where p.EndDate > t.StartDate 
    select p;

foreach (var project in GetAllProjectThatCreatedTimeIsMoreThatFinishedTime)
{
    Console.WriteLine($"Project ID: {project.ProjectId}, Project Name: {project.ProjectName}");
}
   


