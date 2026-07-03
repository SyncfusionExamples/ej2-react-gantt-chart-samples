namespace UrlAdaptor.Server.Models
{

    public class TaskData
    {
        public static List<TaskData> GanttData = new List<TaskData>();
        [System.ComponentModel.DataAnnotations.Key]
        public int taskId { get; set; }

        public string? taskName { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public string? duration { get; set; }

        public int progress { get; set; }

        public int? parentID { get; set; }

        public string? predecessor { get; set; }

        public bool? isParent { get; set; }

        public bool IsExpanded { get; set; }

        public string? info { get; set; }

        public static List<TaskData> GetGanttData()
        {
            if (GanttData.Count == 0)
            {
                Random rand = new Random();
                var x = 0;
                int duration = 0;
                DateTime startDate = new DateTime(2000, 1, 3, 08, 00, 00);
                for (var i = 1; i <= 5; i++)
                {
                    startDate = startDate.AddDays(i == 1 ? 0 : 7);
                    DateTime childStartDate = startDate;
                    TaskData Parent = new TaskData();
                    if (i == 1)
                    {
                        Parent = new TaskData()

                        {
                            taskId = ++x,
                            taskName = "Task " + x,
                            startDate = startDate,
                            endDate = startDate.AddDays(26),
                            duration = "20",
                            progress = rand.Next(100),
                            predecessor = null,
                            isParent = true,
                            parentID = null,
                            IsExpanded = false
                        };
                        GanttData.Add(Parent);
                    }
                    else
                    {
                        Parent = new TaskData()
                        {
                            taskId = ++x,
                            taskName = "Task " + x,
                            startDate = startDate,
                            endDate = startDate.AddDays(26),
                            duration = "20",
                            progress = rand.Next(100),
                            predecessor = null,
                            isParent = true,
                            parentID = null,
                            IsExpanded = false
                        };
                        GanttData.Add(Parent);
                    }
                    for (var j = 1; j <= 3; j++)
                    {
                        childStartDate = childStartDate.AddDays(j == 1 ? 0 : duration + 2);
                        duration = 5;
                        GanttData.Add(new TaskData()
                        {
                            taskId = ++x,
                            taskName = "Task " + x,
                            startDate = childStartDate,
                            endDate = childStartDate.AddDays(5),
                            duration = duration.ToString(),
                            progress = rand.Next(100),
                            parentID = Parent.taskId,
                            predecessor = j > 1 ? (x - 1) + "FS" : "",
                            isParent = false,
                            IsExpanded = false
                        });
                    }
                }
            }
            return GanttData;
        }
    }
}
