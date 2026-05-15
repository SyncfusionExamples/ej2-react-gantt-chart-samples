import React from "react";
import { DataManager, WebMethodAdaptor } from "@syncfusion/ej2-data";
import { GanttComponent, Inject, Edit, Selection, Toolbar, ColumnsDirective, ColumnDirective } from '@syncfusion/ej2-react-gantt';

function App() {
  // Configure DataManager with WebMethodAdaptor
  const data = new DataManager({
    url: "https://localhost:7052/api/Gantt",
    adaptor: new WebMethodAdaptor(),
    crossDomain: true
  });
  const taskFields = {
        id: 'TaskID',
        name: 'TaskName',
        startDate: 'StartDate',
        endDate: 'EndDate',
        duration: 'Duration',
        progress: 'Progress',
        dependency: 'Dependency',
        parentID: 'ParentID',
    };
  const editSettings = {
    allowEditing: true,
    allowAdding: true,
    allowDeleting: true,
    allowTaskbarEditing: true
  };
  const toolbar = ['Add', 'Edit', 'Update', 'Delete', 'Cancel', 'ExpandAll', 'CollapseAll', 'Indent', 'Outdent'];

  return (
    <div className="App">
      <h2>Gantt Data with WebMethodAdaptor</h2>
      <GanttComponent dataSource={data} taskFields={taskFields} editSettings={editSettings} height='400px'  toolbar={toolbar} >
        <ColumnsDirective>
                    <ColumnDirective field="TaskID" headerText="Task ID" textAlign="Right" width="90" type="number" />
                    <ColumnDirective field="TaskName" headerText="Task Name" textAlign="Left" width="270" type="string" />
                    <ColumnDirective field="StartDate" headerText="Start Date" textAlign="Right" width="150" format="yMd" type="dateTime" />
                    <ColumnDirective field="EndDate" headerText="End Date" textAlign="Right" width="150" format="dd/MM/yyyy hh:mm" type="dateTime" />
                    <ColumnDirective field="Duration" headerText="Duration" textAlign="Right" width="90" type="string" />
                    <ColumnDirective field="Progress" headerText="Progress" textAlign="Right" width="120" type="number" />
                </ColumnsDirective>
           <Inject services={[Edit, Selection, Toolbar]}/>
        </GanttComponent>
    </div>
  );
}

export default App;
