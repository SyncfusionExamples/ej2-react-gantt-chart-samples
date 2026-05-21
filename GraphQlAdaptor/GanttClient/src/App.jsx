import { GanttComponent, ColumnsDirective, ColumnDirective, Inject, Edit, Selection, Toolbar } from '@syncfusion/ej2-react-gantt';
import { DataManager, GraphQLAdaptor, Query } from "@syncfusion/ej2-data";
import './App.css'

class GraphQLCrudAdaptor extends GraphQLAdaptor {

  processResponse(resData, ds, query, xhr, request) {

    if (resData && resData.data) {

      const data = resData.data;

      // ✅ READ
      if (data.getTasks) {
        return data.getTasks;
      }

      // ✅ UPDATE
      if (data.updateTask) {
        return { result: data.updateTask };
      }

      // ✅ INSERT
      if (data.addTask) {
        return { result: data.addTask };
      }

      // ✅ DELETE
      if (data.deleteTask !== undefined) {
        return { result: data.deleteTask };
      }

      // ✅ BATCH
      if (data.batchTasks) {
        return data.batchTasks;
      }
    }

    return super.processResponse(resData, ds, query, xhr, request);
  }
}

function App() {
  const taskFields = {
    id: 'TaskID',
    name: 'TaskName',
    startDate: 'StartDate',
    endDate: 'EndDate',
    duration: 'Duration',
    progress: 'Progress',
    dependency: 'Predecessor',
    parentID: 'ParentId',
    segments: 'Segments',
    resourceInfo: 'ResourceInfos',
  };
  const resources = [
    { resourceId: 1, resourceName: 'Martin Tamer' },
    { resourceId: 2, resourceName: 'Rose Fuller' },
    { resourceId: 3, resourceName: 'Margaret Buchanan' },
    { resourceId: 4, resourceName: 'Fuller King' },
    { resourceId: 5, resourceName: 'Davolio Fuller' },
    { resourceId: 6, resourceName: 'Van Jack' },
    { resourceId: 7, resourceName: 'Fuller Buchanan' },
    { resourceId: 8, resourceName: 'Jack Davolio' },
    { resourceId: 9, resourceName: 'Tamer Vinet' },
    { resourceId: 10, resourceName: 'Vinet Fuller' },
    { resourceId: 11, resourceName: 'Bergs Anton' },
    { resourceId: 12, resourceName: 'Construction Supervisor' }
  ];
  const resourceFields = {
    id: 'resourceId',
    name: 'resourceName',
    unit: 'resourceUnit',
    group: 'resourceGroup'
  };
  const editSettings = {
    allowAdding: true,
    allowEditing: true,
    allowDeleting: true,
    allowTaskbarEditing: true,
    showDeleteConfirmDialog: true
  };
  const toolbar = ['Add', 'Edit', 'Update', 'Delete', 'Cancel', 'ExpandAll', 'CollapseAll', 'Indent', 'Outdent'];
  const ganttDataManager = new DataManager({
    url: 'http://localhost:4205/',
    adaptor: new GraphQLCrudAdaptor({
      // Map to { result, count } in your GraphQL payload
      response: {
        result: 'getTasks.result',
        count: 'getTasks.count'
      },

      // READ: fetch flat tasks (no DataManagerInput)
      query: `
      query getTasks {
        getTasks {
          count
          result {
            TaskID
            TaskName
            StartDate
            EndDate
            Duration
            Progress
            ParentId
            Predecessor
            Segments {
              StartDate
              EndDate
              Duration
            }
            ResourceInfos {
              resourceId
              resourceName
              resourceGroup
              resourceUnit
            }
          }
        }
      }
    `,
      mutation: {
        update: 'updateTask',
        insert: 'addTask',
        remove: 'deleteTask'
      },
      // CRUD mutations via helper
      getMutation: function (action) {
        if (action === 'insert') {
          return `
          mutation AddTask($value: GanttTaskInput!) {
            addTask(value: $value) {
              TaskID
              TaskName
              StartDate
              EndDate
              Duration
              Progress
              ParentId
              Predecessor
              Segments {
                StartDate
                EndDate
                Duration
              }
              ResourceInfos {
                resourceId
                resourceName
                resourceGroup
                resourceUnit
              }
            }
          }
        `;
        }

        if (action === 'update') {
          return `
          mutation UpdateTask($value: GanttTaskInput!) {
            updateTask(value: $value) {
              TaskID
              TaskName
              StartDate
              EndDate
              Duration
              Progress
              ParentId
              Predecessor
              Segments {
                StartDate
                EndDate
                Duration
              }
              ResourceInfos {
                resourceId
                resourceName
                resourceGroup
                resourceUnit
              }
            }
          }
        `;
        }

        if (action === 'remove') {
          return `
          mutation DeleteTask($key: ID!) {
            deleteTask(key: $key)
          }`;
        }
        return '';
      }
    }),
    crossDomain: true
  });


  return (
    <div>
      <GanttComponent
        dataSource={ganttDataManager}
        taskFields={taskFields}
        editSettings={editSettings}
        toolbar={toolbar}
        resourceFields={resourceFields} 
        resources={resources} 
        height='400px'>
        <ColumnsDirective>
          <ColumnDirective field='TaskID' width='80' type='number'></ColumnDirective>
          <ColumnDirective field='TaskName' headerText='Job Name' width='250' type='string'></ColumnDirective>
          <ColumnDirective field='StartDate' type='dateTime'></ColumnDirective>
          <ColumnDirective field='EndDate' type='dateTime'></ColumnDirective>
          <ColumnDirective field='Duration' type='number'></ColumnDirective>
          <ColumnDirective field='Progress' type='number'></ColumnDirective>
          <ColumnDirective field='Predecessor' type='string'></ColumnDirective>
        </ColumnsDirective>
        <Inject services={[Edit, Selection, Toolbar]} />
      </GanttComponent>
    </div>
  )
}

export default App
