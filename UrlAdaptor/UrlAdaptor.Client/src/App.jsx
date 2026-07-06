import { GanttComponent,Inject, Edit, Selection, Toolbar, ColumnsDirective, ColumnDirective } from '@syncfusion/ej2-react-gantt';
import { DataManager, UrlAdaptor } from '@syncfusion/ej2-data';
function App() {
  const dataSource = new DataManager({
    url: `https://localhost:7207/api/Gantt/DataSource`,
    batchUrl: 'https://localhost:7207/api/Gantt/BatchUpdate',
    adaptor: new UrlAdaptor(),
    crossDomain: true
  });
  const taskFields = {
    id: 'taskId',
    name: 'taskName',
    startDate: 'startDate',
    endDate: 'endDate',
    duration: 'duration',
    progress: 'progress',
    dependency: 'predecessor',
    parentID: 'parentID',
  };
  const editSettings = {
    allowAdding: true,
    allowEditing: true,
    allowDeleting: true,
    allowTaskbarEditing: true,
    showDeleteConfirmDialog: true
  };  
  const splitterSettings = {
    columnIndex: 3
  };
  const gridLines = 'Both';
  const toolbar = ['Add', 'Edit', 'Update', 'Delete', 'Cancel'];
  const timelineSettings = {
    topTier: {
      unit: 'Week',
      format: 'MMM dd, y',
    },
    bottomTier: {
      unit: 'Day',
    },
  };
  const labelSettings = {
    leftLabel: 'taskName',
  };

  return (
    <>
      <GanttComponent id='UrlAdaptorGantt' 
        dataSource={dataSource} 
        dateFormat={'MMM dd, y'} 
        treeColumnIndex={1} 
        allowSelection={true} 
        highlightWeekends={true} 
        enableHover={true} 
        taskFields={taskFields} 
        timelineSettings={timelineSettings} 
        labelSettings={labelSettings} 
        splitterSettings={splitterSettings} 
        height='650px' 
        width='100%'
        editSettings={editSettings} 
        gridLines={gridLines} 
        toolbar={toolbar} 
        >
        <ColumnsDirective>
          <ColumnDirective field='taskId' width='80'></ColumnDirective>
          <ColumnDirective field='taskName' headerText='Job Name' width='250' clipMode='EllipsisWithTooltip'></ColumnDirective>
          <ColumnDirective field='startDate' width='120'></ColumnDirective>
          <ColumnDirective field='endDate' width='120'></ColumnDirective>
          <ColumnDirective field='duration' width='120'></ColumnDirective>
          <ColumnDirective field='progress' width='120'></ColumnDirective>
          <ColumnDirective field='predecessor' width='120'></ColumnDirective>
        </ColumnsDirective>
        <Inject services={[Edit, Selection, Toolbar]}/>
      </GanttComponent>
    </>
  )
}

export default App
