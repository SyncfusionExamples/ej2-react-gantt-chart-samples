export interface GanttTask {
  TaskID: number;
  TaskName: string;
  StartDate?: string;
  EndDate?: string;
  Duration?: number;
  Progress?: number;
  ParentId?: number | string;
  Predecessor?: string;
  Segments?: SegmentsInfo[];
  ResourceInfos?: ResourceInfo[];
}
export interface GanttTaskInput {
  TaskID: number;
  TaskName: string;
  StartDate?: string;
  EndDate?: string;
  Duration?: number;
  Progress?: number;
  ParentId?: number | string;
  Predecessor?: string;
  Segments?: SegmentsInfo[];
  ResourceInfos?: ResourceInfo[];
}
export interface CreateTaskArgs {
  value: GanttTaskInput;
}
export interface UpdateTaskArgs {
  value: GanttTaskInput;
}
export interface DeleteTaskArgs {
  key: number;
}
/** Return shape for getTasks */
export interface GanttReturnType {
  result: GanttTask[];
  count: number;
}

export interface SegmentsInfo{
  StartDate?: string;
  EndDate?: string;
  Duration?: number;
}
export interface ResourceInfo{
  resourceId: number;
  resourceName?: string;
  resourceUnit?: number;
  resourceGroup?: string;
}