import { GanttTask } from './types';

export const taskDetails: GanttTask[] = [
  { TaskID: 1, TaskName: 'Planning and Permits', StartDate: '2025-04-02', EndDate: '2025-04-10', Duration: 7, Progress: 100 },
  {
    TaskID: 2, TaskName: 'Site Evaluation', StartDate: '2025-04-02', EndDate: '2025-04-06', Duration: 4, Progress: 100, ParentId: 1, Segments: [
      { StartDate: '04/02/2025', Duration: 2 },
      { StartDate: '04/04/2025', Duration: 2 }
    ], ResourceInfos: [{ resourceId: 1 }]
  },
  { TaskID: 3, TaskName: 'Site Evaluation', StartDate: '2025-04-02', EndDate: '2025-04-04', Duration: 2, Progress: 100, ParentId: 1 }
];