import { GanttTask, CreateTaskArgs, UpdateTaskArgs, DeleteTaskArgs, GanttReturnType } from './types';
import { taskDetails } from './data';
let tasks: GanttTask[] = [...taskDetails];
const resolvers = {
  Query: {
    // Return all tasks + total count
    getTasks: (): GanttReturnType => {
      return {
        result: tasks,
        count: tasks.length
      };
    },
    task: (_: unknown, { id }: { id: string | number }): GanttTask | null => {
      return tasks.find(t => String(t.TaskID) === String(id)) || null;
    }
  },
  Mutation: {
    addTask: (_: unknown, { value }: CreateTaskArgs): GanttTask => {
      const exists = tasks.find(t => String(t.TaskID) === String(value.TaskID));
      if (exists) throw new Error('TaskID already exists');
      const newTask: GanttTask = { ...value };
      tasks.push(newTask);
      return newTask;
    },
    updateTask: (_: unknown, { value }: UpdateTaskArgs): GanttTask => {
      const taskIndex = tasks.findIndex(t => String(t.TaskID) === String(value.TaskID));
      if (taskIndex === -1) throw new Error('Task not found');
      tasks[taskIndex] = { ...tasks[taskIndex], ...value };
      return tasks[taskIndex];
    },
    deleteTask: (_: unknown, { key }: DeleteTaskArgs): boolean => {
      const taskIndex = tasks.findIndex(t => String(t.TaskID) === String(key));
      if (taskIndex === -1) return false;
      tasks.splice(taskIndex, 1); // simple delete
      return true;
    },
    
  }
};
export default resolvers;
