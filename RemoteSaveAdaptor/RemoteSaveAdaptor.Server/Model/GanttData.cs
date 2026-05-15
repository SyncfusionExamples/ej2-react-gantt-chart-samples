namespace RemoteSaveAdaptor.Server.Model
{
    public static class GanttData
    {
        public static List<GanttTask> GetAllTasks()
        {
            return new List<GanttTask>
            {
                new GanttTask
                {
                    TaskId = 1,
                    TaskName = "Project Initiation",
                    StartDate = new DateTime(2025, 1, 1)
                },
                new GanttTask
                {
                    TaskId = 2,
                    TaskName = "Requirement Analysis",
                    StartDate = new DateTime(2025, 1, 2),
                    Duration = 5,
                    Progress = 40,
                    ParentId = 1
                },
                new GanttTask
                {
                    TaskId = 3,
                    TaskName = "Development",
                    StartDate = new DateTime(2025, 1, 8),
                    Duration = 10,
                    Progress = 20,
                    ParentId = 1
                },
                new GanttTask
                {
                    TaskId = 4,
                    TaskName = "Testing",
                    StartDate = new DateTime(2025, 1, 20),
                    Duration = 4,
                    Progress = 0,
                    ParentId = 1
                }
            };
        }
    }
}
