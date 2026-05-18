import { DataManager, ODataV4Adaptor } from '@syncfusion/ej2-data';
import { GanttComponent, Inject, Edit, Selection, Toolbar, ColumnsDirective, ColumnDirective, ContextMenu } from '@syncfusion/ej2-react-gantt';
import './App.css';

function App() {
    // Create DataManager with ODataV4Adaptor
    const data = new DataManager({

        url: 'https://localhost:7199/odata/GanttTasks', // To change the port, update it in launchSettings.json (server app) and reflect it here
        adaptor: new ODataV4Adaptor(),
        key: 'TaskID',
        crossDomain: true
    });
    const resourceFields = {
        id: 'resourceId',
        name: 'resourceName',
        unit: 'resourceUnit',
        group: 'resourceGroup'
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
    const taskFields = {
        id: 'TaskID',
        name: 'TaskName',
        startDate: 'StartDate',
        endDate: 'EndDate',
        duration: 'Duration',
        progress: 'Progress',
        dependency: 'Dependency',
        parentID: 'ParentID',
        segments: 'Segments',
        resourceInfo: 'ResourceInfos',
    };
    const editSettings = {
        allowEditing: true,
        allowAdding: true,
        allowDeleting: true,
        allowTaskbarEditing: true
    };
    const toolbar = ['Add', 'Edit', 'Update', 'Delete', 'Cancel', 'ExpandAll', 'CollapseAll', 'Indent', 'Outdent'];

    return (
        <div style={{ margin: '20px' }}>
            <h2>ODataV4Adaptor with Gantt</h2>
            <GanttComponent dataSource={data} taskFields={taskFields} resourceFields={resourceFields} resources={resources}
                editSettings={editSettings} height='400px' toolbar={toolbar} enableContextMenu={true}>
                <ColumnsDirective>
                    <ColumnDirective field="TaskID" headerText="Task ID" textAlign="Right" width="90" type="number" isPrimaryKey={true} />
                    <ColumnDirective field="TaskName" headerText="Task Name" textAlign="Left" width="270" type="string" />
                    <ColumnDirective field="StartDate" headerText="Start Date" textAlign="Right" width="150" format="yMd" type="dateTime" />
                    <ColumnDirective field="EndDate" headerText="End Date" textAlign="Right" width="150" format="dd/MM/yyyy hh:mm" type="dateTime" />
                    <ColumnDirective field="Duration" headerText="Duration" textAlign="Right" width="90" type="number" />
                    <ColumnDirective field="Progress" headerText="Progress" textAlign="Right" width="120" type="number" />
                </ColumnsDirective>
                <Inject services={[Edit, Selection, Toolbar, ContextMenu]} />
            </GanttComponent>
        </div>
    );
}

export default App;
