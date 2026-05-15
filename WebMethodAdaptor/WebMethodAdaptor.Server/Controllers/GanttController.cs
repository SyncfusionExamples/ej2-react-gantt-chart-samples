using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using WebMethodAdaptorDemo.Server.Models;

namespace WebMethodAdaptorDemo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GanttController : ControllerBase
    {
        [HttpGet]
        public List<GanttTask> GetOrderData()
        {
            return GanttDataAdaptor.GetGanttTasks().ToList();
        }

        [HttpPost]
        public object Post([FromBody] CRUDModel<GanttTask> data)
        {

            if (data == null)
                return BadRequest();

            // Work against the single backing list once
            var tasks = GanttDataAdaptor.GetGanttTasks(); // assume List<GanttTask>

            if (data.action == "batch")
            {
                // Added: assign TaskID if missing and add to backing list
                if (data.added != null)
                {
                    int nextId = tasks.Any() ? tasks.Max(t => t.TaskID) + 1 : 1;
                    foreach (var task in data.added)
                    {
                        if (task.TaskID == 0)
                            task.TaskID = nextId++;
                        tasks.Add(task);
                    }
                }

                // Changed: update existing items safely (check for null)
                if (data.changed != null)
                {
                    foreach (var task in data.changed)
                    {
                        var existing = tasks.FirstOrDefault(t => t.TaskID == task.TaskID);
                        if (existing == null) continue;

                        existing.TaskName = task.TaskName;
                        existing.StartDate = task.StartDate;
                        existing.EndDate = task.EndDate;
                        existing.Duration = task.Duration;
                        existing.Progress = task.Progress;
                        existing.Dependency = task.Dependency;
                        existing.ParentID = task.ParentID;
                    }
                }

                // Deleted: remove by TaskID
                if (data.deleted != null)
                {
                    foreach (var task in data.deleted)
                    {
                        var existing = tasks.FirstOrDefault(t => t.TaskID == task.TaskID);
                        if (existing != null)
                            tasks.Remove(existing);
                    }
                }
            }

            // Return the updated data and count
            var dataSource = tasks.AsQueryable();
            int totalRecordsCount = tasks.Count;
            return Ok(new { result = dataSource, count = totalRecordsCount });
        }
    }
    public class CRUDModel<T>
        where T : class
    {
        public string? action { get; set; }
        public string? keyColumn { get; set; }
        public object? key { get; set; }
        public T? value { get; set; }
        public List<T>? added { get; set; }
        public List<T>? changed { get; set; }
        public List<T>? deleted { get; set; }
        public IDictionary<string, object>? @params { get; set; }
    }
}
