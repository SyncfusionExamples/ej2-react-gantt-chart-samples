//import { setValue } from '@syncfusion/ej2-base';
import { ODataV4Adaptor, } from '@syncfusion/ej2-data';
export class CustomAdaptor extends ODataV4Adaptor {
    processResponse() {
        //let i = 0;
        const original = super.processResponse.apply(this, arguments);
        /* Adding serial number */
        return original;
    }

    processQuery(dm, query) {
        dm.dataSource.url = 'https://localhost:7284/odata/GanttTasks';
        query.addParams('Syncfusion in React Gantt', 'true');
        const result = super.processQuery.apply(this, arguments);
        return result;

    }

    beforeSend(dm, request, settings) {
        request.headers.set('Authorization', `Bearer${(window).token}`);
        super.beforeSend(dm, request, settings);
    }
}