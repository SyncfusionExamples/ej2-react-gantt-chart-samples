namespace WebMethodAdaptorDemo.Server.Models
{

    public static class GanttDataAdaptor
    {
        public static List<GanttTask> GetGanttTasks()
        {
            var ganttTasks = new List<GanttTask>();

            // ✅ Parent task
            ganttTasks.Add(new GanttTask
            {
                TaskID = 1,
                ParentID = null,
                TaskName = "Project Planning",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(10),
                Duration = "10 Days",
                Progress = 40,
                Dependency = null
            });

            // ✅ Child tasks
            ganttTasks.Add(new GanttTask
            {
                TaskID = 2,
                ParentID = 1,
                TaskName = "Requirement Analysis",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(3),
                Duration = "3 Days",
                Progress = 100,
                Dependency = null
            });

            ganttTasks.Add(new GanttTask
            {
                TaskID = 3,
                ParentID = 1,
                TaskName = "Design",
                StartDate = DateTime.Today.AddDays(3),
                EndDate = DateTime.Today.AddDays(6),
                Duration = "3 Days",
                Progress = 70,
                Dependency = "2FS"
            });

            ganttTasks.Add(new GanttTask
            {
                TaskID = 4,
                ParentID = 1,
                TaskName = "Development",
                StartDate = DateTime.Today.AddDays(6),
                EndDate = DateTime.Today.AddDays(9),
                Duration = "3 Days",
                Progress = 40,
                Dependency = "3FS"
            });

            ganttTasks.Add(new GanttTask
            {
                TaskID = 5,
                ParentID = 1,
                TaskName = "Testing",
                StartDate = DateTime.Today.AddDays(9),
                EndDate = DateTime.Today.AddDays(10),
                Duration = "1 Day",
                Progress = 0,
                Dependency = "4FS"
            });

            return ganttTasks;
        }
    }

    public class GanttTask
    {
        public int TaskID { get; set; }
        public string? TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Duration { get; set; }          // days
        public int Progress { get; set; }          // 0–100
        public string? Dependency { get; set; }    // ex: "1FS,2SS"
        public int? ParentID { get; set; }
    }
}
