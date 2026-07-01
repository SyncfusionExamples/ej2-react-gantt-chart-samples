using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Diagnostics;
using UrlAdaptor.Server.Models;

namespace UrlAdaptor.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GanttController : Controller
    {
        private readonly ILogger<GanttController> _logger;

        public GanttController(ILogger<GanttController> logger)
        {
            _logger = logger;
        }
        public static List<TaskData> DataList = null;

        [HttpPost("DataSource")]
        public IActionResult DataSource([FromBody] DataManagerRequest dm)
        {
            var dataSource = TaskData.GetGanttData();
            int count = dataSource.Count;
            DataList = dataSource;

            return dm.RequiresCounts
                ? Json(new { result = dataSource, count = count })
                : Json(dataSource);
        }
        public class CRUDModel
        {
            public List<TaskData>? Added { get; set; }
            public List<TaskData>? Changed { get; set; }
            public List<TaskData>? Deleted { get; set; }
            public TaskData? Value { get; set; }
            public int key { get; set; }
            public string? action { get; set; }
        }
        [HttpPost("BatchUpdate")]
        public IActionResult BatchUpdate([FromBody] CRUDModel batchmodel)
        {
            try
            {
                if (batchmodel.Changed != null && batchmodel.Changed.Count != null)
                {
                    for (var i = 0; i < batchmodel.Changed.Count(); i++)
                    {
                        var value = batchmodel.Changed[i];
                        TaskData result = DataList.Where(or => or.taskId == value.taskId).FirstOrDefault();
                        result.taskId = value.taskId;
                        result.taskName = value.taskName;
                        result.startDate = value.startDate;
                        result.endDate = value.endDate;
                        result.duration = value.duration;
                        result.progress = value.progress;
                        result.predecessor = value.predecessor;
                        result.parentID = value.parentID;
                        result.info = value.info;
                    }
                }
                if (batchmodel.Deleted != null)
                {
                    for (var i = 0; i < batchmodel.Deleted.Count; i++)
                    {
                        DataList.Remove(DataList.Where(ds => ds.taskId == batchmodel.Deleted[i].taskId).FirstOrDefault());
                    }
                }
                if (batchmodel.Added != null)
                {
                    for (var i = 0; i < batchmodel.Added.Count(); i++)
                    {
                        DataList.Insert(0, batchmodel.Added[i]);
                    }

                }
                return Json(new { addedRecords = batchmodel.Added, changedRecords = batchmodel.Changed, deletedRecords = batchmodel.Deleted });
            }
            catch (Exception ex)
            {
                // Return the exception message in the response
                return StatusCode(500, new
                {
                    error = ex.Message
                });
            }
        }
    }
}
