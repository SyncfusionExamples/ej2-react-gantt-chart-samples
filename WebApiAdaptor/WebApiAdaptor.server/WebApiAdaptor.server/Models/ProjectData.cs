using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectData_Service.Models
{
    public class ProjectData
    {
        public List<GanttDataSource> GetUrlDataSource()
        {


            List<GanttDataSource> dataCollection = new List<GanttDataSource>();
            dataCollection = new List<GanttDataSource>() {
               new GanttDataSource(){
                    taskId = 1,
                    taskName = "Project initiation",
                    startDate = new DateTime(2019, 03, 29),
                    endDate = new DateTime(2019, 04, 21),
                      resources = new List<ResourceModel>
                {
                   new ResourceModel { resourceId = 1, resourceUnit = 70 },
                   new ResourceModel { resourceId = 6 }
                }
                },
               new GanttDataSource(){
                    taskId = 2,
                    taskName = "Identify Site location",
                    startDate = new DateTime(2019, 03, 29),
                    endDate = new DateTime(2019, 04, 21),
                    duration = "2",
                    progress = 30,
                    parentID = 1,
                    resources = new List<ResourceModel>
                {
                   new ResourceModel { resourceId = 1, resourceUnit = 70 },
                   new ResourceModel { resourceId = 6 }
                }
                },
               new GanttDataSource(){
                    taskId = 3,
                    taskName = "Perform soil test",
                    startDate = new DateTime(2019, 03, 29),
                    endDate = new DateTime(2019, 04, 21),
                    duration = "4",
                    parentID = 1,
                    resources = new List<ResourceModel>
                        {
                            new ResourceModel { resourceId = 2},
                            new ResourceModel{ resourceId = 3 },
                            new ResourceModel{ resourceId = 5 }
                        }
                },
               new GanttDataSource(){
                    taskId = 4,
                    taskName = "Soil test approval",
                    startDate = new DateTime(2019, 03, 29),
                    endDate = new DateTime(2019, 04, 21),
                    duration = "1",
                    progress = 30,
                    parentID = 1,
                    resources = new List<ResourceModel>
                        {
                           new ResourceModel { resourceId = 8 },
                        new ResourceModel { resourceId = 9, resourceUnit = 50 }
                        }
                },
               new GanttDataSource(){
                    taskId = 5,
                    taskName = "Project estimation",
                    startDate = new DateTime(2019, 03, 29),
                    endDate = new DateTime(2019, 04, 21),
                    
                },
               new GanttDataSource(){
                    taskId = 6,
                    taskName = "Develop floor plan for estimation",
                    startDate = new DateTime(2019, 03, 29),
                    endDate = new DateTime(2019, 04, 21),
                    duration = "3",
                    progress = 30,
                    parentID = 5,
                    predecessor = "4",
                    resources = new List<ResourceModel>
                        {
                           new ResourceModel { resourceId = 4, resourceUnit = 60 }
                        }
                },
               new GanttDataSource()
               {
                   taskId = 7,
                   taskName = "List materials",
                   startDate = new DateTime(2019, 04, 01),
                   endDate = new DateTime(2019, 04, 21),
                   duration = "3",
                   parentID = 5,
                   predecessor = "6",
                   resources = new List<ResourceModel>
                        {
                           new ResourceModel { resourceId = 8 },
                         new ResourceModel{ resourceId = 4 }
                        }
               },
               new GanttDataSource()
               {
                   taskId = 8,
                   taskName = "Estimation approval",
                   startDate = new DateTime(2019, 04, 01),
                   endDate = new DateTime(2019, 04, 21),
                   duration = "2",
                   parentID = 5,
                   predecessor = "7",
                   resources = new List<ResourceModel>
                        {
                           new ResourceModel { resourceId = 12 },
                         new ResourceModel{ resourceId = 5, resourceUnit = 70 }
                        }
               },
               new GanttDataSource()
               {
                   taskId = 9,
                   taskName = "Sign contract",
                   startDate = new DateTime(2019, 04, 01),
                   endDate = new DateTime(2019, 04, 21),
                   duration = "1",
                   predecessor = "8",
                   progress = 30,
                   resources = new List<ResourceModel>
                        {
                           new ResourceModel { resourceId = 12 }
                    }
               }

            };
            return dataCollection;

        }



        public List<GanttResources> GetResources()
        {
            List<GanttResources> GanttResourcesCollection = new List<GanttResources>();

            GanttResources Record1 = new GanttResources()
            {
                resourceId = 1,
                ResourceName = "Martin Tamer"
            };
            GanttResources Record2 = new GanttResources()
            {
                resourceId = 2,
                ResourceName = "Rose Fuller"
            };
            GanttResources Record3 = new GanttResources()
            {
                resourceId = 3,
                ResourceName = "Margaret Buchanan"
            };
            GanttResources Record4 = new GanttResources()
            {
                resourceId = 4,
                ResourceName = "Fuller King"
            };
            GanttResources Record5 = new GanttResources()
            {
                resourceId = 5,
                ResourceName = "Davolio Fuller"
            };
            GanttResources Record6 = new GanttResources()
            {
                resourceId = 6,
                ResourceName = "Van Jack"
            };
            GanttResources Record7 = new GanttResources()
            {
                resourceId = 7,
                ResourceName = "Fuller Buchanan"
            };
            GanttResources Record8 = new GanttResources()
            {
                resourceId = 8,
                ResourceName = "Jack Davolio"
            };
            GanttResources Record9 = new GanttResources()
            {
                resourceId = 9,
                ResourceName = "Tamer Vinet"
            };
            GanttResources Record10 = new GanttResources()
            {
                resourceId = 10,
                ResourceName = "Vinet Fuller"
            };
            GanttResources Record11 = new GanttResources()
            {
                resourceId = 11,
                ResourceName = "Bergs Anton"
            };
            GanttResources Record12 = new GanttResources()
            {
                resourceId = 12,
                ResourceName = "Construction Supervisor"
            };
            GanttResourcesCollection.Add(Record1);
            GanttResourcesCollection.Add(Record2);
            GanttResourcesCollection.Add(Record3);
            GanttResourcesCollection.Add(Record4);
            GanttResourcesCollection.Add(Record5);
            GanttResourcesCollection.Add(Record6);
            GanttResourcesCollection.Add(Record7);
            GanttResourcesCollection.Add(Record8);
            GanttResourcesCollection.Add(Record9);
            GanttResourcesCollection.Add(Record10);
            GanttResourcesCollection.Add(Record11);
            GanttResourcesCollection.Add(Record12);
            return GanttResourcesCollection;
        }

        public class GanttDataSource
        {
            public int taskId { get; set; }
            public string taskName { get; set; }
            public DateTime? startDate { get; set; }
            public DateTime? endDate { get; set; }
            public string duration { get; set; }
            public int progress { get; set; }
            public string predecessor { get; set; }
            public int? parentID { get; set; }
            public List<ResourceModel> resources { get; set; }
            public string customColumn { get; set; }

        }

        public class GanttResources
        {
            public int resourceId { get; set; }
            public string ResourceName { get; set; }
            public Nullable<int> Unit { get; set; }

        }
        public class ResourceModel
        {
            public int resourceId { get; set; }
            public Nullable<int> resourceUnit { get; set; }
         }

    }
}
