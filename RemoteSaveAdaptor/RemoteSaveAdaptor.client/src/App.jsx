
import './App.css';
import { GanttComponent, Inject, Edit, Selection, Toolbar, ColumnsDirective, ColumnDirective } from '@syncfusion/ej2-react-gantt';
import React, { useEffect, useState, useRef } from "react";
import { DataManager, RemoteSaveAdaptor } from "@syncfusion/ej2-data";

function App() {

    const hasLoadedRef = useRef(false);
    const [data, setData] = useState(null);

    useEffect(() => {
        if (hasLoadedRef.current) {
            return;
        }

        hasLoadedRef.current = true;

        fetch('https://localhost:7007/api/gantt') // Replace 7007 with your port number
            .then(res => res.json())
            .then(result => {
                setData(new DataManager({
                    json: result,
                    adaptor: new RemoteSaveAdaptor(),
                    batchUrl: 'https://localhost:7007/api/gantt/Batch', // Replace 7007 with your port number
                    enableOffline: true
                }));
            });
    }, []);

    const taskFields = {
        id: 'taskId',
        name: 'taskName',
        startDate: 'startDate',
        endDate: 'endDate',
        duration: 'duration',
        progress: 'progress',
        parentID: 'parentId'
    };
    const editSettings = {
        allowEditing: true,
        allowAdding: true,
        allowDeleting: true,
        allowTaskbarEditing: true
    };
    const toolbarOptions = ["Add", "Edit", "Delete", "Update", "Cancel"];
    return (
        <div>
            {data && (
                <GanttComponent dataSource={data} taskFields={taskFields} allowSelection={true} editSettings={editSettings} height='400px' toolbar={toolbarOptions}>
                    <ColumnsDirective>
                        <ColumnDirective field="taskId" headerText="Task ID" textAlign="Right" width="90" type="number" />
                        <ColumnDirective field="taskName" headerText="Task Name" textAlign="Left" width="270" type="string" />
                        <ColumnDirective field="startDate" headerText="Start Date" textAlign="Right" width="150" format="yMd" type="dateTime" />
                        <ColumnDirective field="endDate" headerText="End Date" textAlign="Right" width="150" format="dd/MM/yyyy hh:mm" type="dateTime" />
                        <ColumnDirective field="duration" headerText="Duration" textAlign="Right" width="90" type="number" />
                        <ColumnDirective field="progress" headerText="Progress" textAlign="Right" width="120" type="number" />
                    </ColumnsDirective>
                    <Inject services={[Edit, Selection, Toolbar]} />
                </GanttComponent>
            )
            }
        </div>
    );
}

export default App;
