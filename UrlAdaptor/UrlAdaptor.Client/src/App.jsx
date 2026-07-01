import { useState } from 'react'
import { GanttComponent,Inject, Edit, Selection, Toolbar, ColumnsDirective, ColumnDirective, Filter } from '@syncfusion/ej2-react-gantt';
import { DataManager, UrlAdaptor } from '@syncfusion/ej2-data';
function App() {
  const dataSource = new DataManager({
    url: `https://localhost:7207/api/Gantt/DataSource`,
    batchUrl: 'https://localhost:7207/api/Gantt/BatchUpdate',
    adaptor: new UrlAdaptor(),
    crossDomain: true
  });
  let ganttInstance;
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
  const actionbegin = (args) => {
       
  };
  const splitterSettings = {
    columnIndex: 3
  };
  const onCreated = () => {
        
  };
  const projectStartDate = new Date('03/26/2025');
  const projectEndDate = new Date('09/10/2025');
  const gridLines = 'Both';
  const toolbar = ['Add', 'Edit', 'Update', 'Delete', 'Cancel', 'ExpandAll', 'CollapseAll', 'Indent', 'Outdent'];
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
      <GanttComponent id='Editing' 
        ref={gantt => ganttInstance = gantt} 
        dataSource={dataSource} 
        dateFormat={'MMM dd, y'} 
        treeColumnIndex={1} 
        allowSelection={true} 
        highlightWeekends={true} 
        created={onCreated} 
        allowFiltering={true}
        enableHover={true} 
        taskFields={taskFields} 
        timelineSettings={timelineSettings} 
        labelSettings={labelSettings} 
        splitterSettings={splitterSettings} 
        height='650px' 
        editSettings={editSettings} 
        gridLines={gridLines} 
        toolbar={toolbar} 
        actionBegin={actionbegin}
        >
        <ColumnsDirective>
          <ColumnDirective field='taskId' width='80'></ColumnDirective>
          <ColumnDirective field='taskName' headerText='Job Name' width='250' clipMode='EllipsisWithTooltip'></ColumnDirective>
          <ColumnDirective field='startDate'></ColumnDirective>
          <ColumnDirective field='endDate' ></ColumnDirective>
          <ColumnDirective field='duration'></ColumnDirective>
          <ColumnDirective field='progress'></ColumnDirective>
          <ColumnDirective field='predecessor'></ColumnDirective>
        </ColumnsDirective>
        <Inject services={[Edit, Selection, Toolbar, Filter]}/>
      </GanttComponent>
    </>
  )
}

export default App
