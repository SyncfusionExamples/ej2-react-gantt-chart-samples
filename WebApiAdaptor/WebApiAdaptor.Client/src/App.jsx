import { createRoot } from 'react-dom/client';
import './index.css';
import * as React from 'react';
import { useEffect, useState } from 'react';
import { GanttComponent, Inject, Selection, ColumnsDirective, ColumnDirective, Edit } from '@syncfusion/ej2-react-gantt';
import { DataManager, WebApiAdaptor } from '@syncfusion/ej2-data';

const App = () => {
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
    const projectStartDate = new Date('03/23/2019');
    const projectEndDate = new Date('06/10/2019');
    const gridLines = 'Both';
    const timelineSettings = {
        timelineUnitSize: 50,
        topTier: {
            unit: 'Month',
            format: 'MMM dd, y',
        },
        bottomTier: {
            unit: 'Day',
        },
    };
    const dataSource = new DataManager({
        url: 'http://localhost:61046/api/Orders/',
        adaptor: new WebApiAdaptor,
        crossDomain: true
    });
    const labelSettings = {
        leftLabel: 'taskName'
    };
    const editSettings = {
      allowAdding: true,
      allowEditing: true,
      allowDeleting: true,
      allowTaskbarEditing: true,
      showDeleteConfirmDialog: true
  };
    return (<div className='control-pane'>
      <div className='control-section'>
        <GanttComponent id='RemoteData' dataSource={dataSource} projectStartDate={projectStartDate} projectEndDate={projectEndDate} allowSorting={true} dateFormat={'MMM dd, y'}  allowSelection={true} highlightWeekends={false} includeWeekend={true} allowUnscheduledTasks={true}  taskFields={taskFields} gridLines={gridLines} timelineSettings={timelineSettings} labelSettings={labelSettings} height='400px' editSettings={editSettings}>
          <ColumnsDirective>
            <ColumnDirective field='taskId' ></ColumnDirective>
            <ColumnDirective field='taskName' headerText='Task Name' width='250' clipMode='EllipsisWithTooltip'></ColumnDirective>
            <ColumnDirective field='startDate'></ColumnDirective>
            <ColumnDirective field='endDate'></ColumnDirective>
            <ColumnDirective field='duration'></ColumnDirective>
            <ColumnDirective field='progress'></ColumnDirective>
            <ColumnDirective field='predecessor' ></ColumnDirective>
          </ColumnsDirective>
          <Inject services={[Selection, Edit]}/>
        </GanttComponent>
        
      </div>

    </div>);
};
export default App;