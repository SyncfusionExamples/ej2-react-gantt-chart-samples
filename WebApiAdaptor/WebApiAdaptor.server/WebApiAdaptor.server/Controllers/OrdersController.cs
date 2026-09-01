using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectData_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static ProjectData_Service.Models.ProjectData;

namespace AngularwithASPCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        public static List<GanttDataSource> DataList = null;
        // GET: api/Orders
        [HttpGet]
       public object Get()
        {
            if (DataList == null)
            {
                ProjectData datasource = new ProjectData();
                DataList = datasource.GetUrlDataSource();
            }
           return Json(new { Items = DataList, Count = DataList.Count() });
        }

        // POST: api/Orders
        [HttpPost]
        public object Post([FromBody]GanttDataSource[] value)
        {
            for (var i = 0; i < value.Count(); i++)
            {
                DataList.Insert(0, value[i]);
            }
            return value;
        }


        // PUT: api/Orders/5
        [HttpPut]
        public object Put([FromBody] GanttDataSource[] value)
        {
            for (var i = 0; i < value.Length; i++)
            {
                var ord = value[i];
                GanttDataSource val = DataList.Where(or => or.taskId == ord.taskId).FirstOrDefault();
                val.taskId = ord.taskId;
                val.taskName = ord.taskName;
                val.startDate = ord.startDate;
                val.endDate = ord.endDate;
                val.duration = ord.duration;
                val.progress = ord.progress;
                val.predecessor = ord.predecessor;
                val.parentID = ord.parentID;
            }
            return value;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:int}")]
        [Route("Orders/{id:int}")]
        public object Delete(int id)
        {
            DataList.Remove(DataList.Where(or => or.taskId == id).FirstOrDefault());
            return Json(id);
        }
    }
    public class Data
    {

        public bool requiresCounts { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
    }

}