import React, {
    useCallback,
    useMemo,
    useEffect,
    useRef,
    useState,
    StrictMode,
} from "react";

import { AgGridReact } from 'ag-grid-react'; // React Data Grid Component
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the Data Grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the Data Grid

const AgDataGridEx = () => {
    console.log('AgDataGridEx is being rendered');
    // Row Data: The data to be displayed.

    /*
    const [rowData, setRowData] = useState([
        { make: 'Tesla', model: 'Model Y', price: 64950, electric: true, month: 'June' },
        { make: 'Ford', model: 'F-Series', price: 33850, electric: false, month: 'October' },
        { make: 'Toyota', model: 'Corolla', price: 29600, electric: false, month: 'August' },
        { make: 'Mercedes', model: 'EQA', price: 48890, electric: true, month: 'February' },
        { make: 'Fiat', model: '500', price: 15774, electric: false, month: 'January' },
        { make: 'Nissan', model: 'Juke', price: 20675, electric: false, month: 'March' },
        { make: 'Vauxhall', model: 'Corsa', price: 18460, electric: false, month: 'July' },
        { make: 'Volvo', model: 'EX30', price: 33795, electric: true, month: 'September' },
        { make: 'Mercedes', model: 'Maybach', price: 175720, electric: false, month: 'December' },
        { make: 'Vauxhall', model: 'Astra', price: 25795, electric: false, month: 'April' },
        { make: 'Fiat', model: 'Panda', price: 13724, electric: false, month: 'November' },
        { make: 'Jaguar', model: 'I-PACE', price: 69425, electric: true, month: 'May' },
        { make: 'Tesla', model: 'Model Y', price: 64950, electric: true, month: 'June' },
        { make: 'Ford', model: 'F-Series', price: 33850, electric: false, month: 'October' },
        { make: 'Toyota', model: 'Corolla', price: 29600, electric: false, month: 'August' },
        { make: 'Mercedes', model: 'EQA', price: 48890, electric: true, month: 'February' },
        { make: 'Fiat', model: '500', price: 15774, electric: false, month: 'January' },
        { make: 'Nissan', model: 'Juke', price: 20675, electric: false, month: 'March' },
        { make: 'Vauxhall', model: 'Corsa', price: 18460, electric: false, month: 'July' },
        { make: 'Volvo', model: 'EX30', price: 33795, electric: true, month: 'September' },
        { make: 'Mercedes', model: 'Maybach', price: 175720, electric: false, month: 'December' },
        { make: 'Vauxhall', model: 'Astra', price: 25795, electric: false, month: 'April' },
        { make: 'Fiat', model: 'Panda', price: 13724, electric: false, month: 'November' },
        { make: 'Jaguar', model: 'I-PACE', price: 69425, electric: true, month: 'May' },
        { make: 'Tesla', model: 'Model Y', price: 64950, electric: true, month: 'June' },
        { make: 'Ford', model: 'F-Series', price: 33850, electric: false, month: 'October' },
        { make: 'Toyota', model: 'Corolla', price: 29600, electric: false, month: 'August' },
        { make: 'Mercedes', model: 'EQA', price: 48890, electric: true, month: 'February' },
        { make: 'Fiat', model: '500', price: 15774, electric: false, month: 'January' },
        { make: 'Nissan', model: 'Juke', price: 20675, electric: false, month: 'March' },
        { make: 'Vauxhall', model: 'Corsa', price: 18460, electric: false, month: 'July' },
        { make: 'Volvo', model: 'EX30', price: 33795, electric: true, month: 'September' },
        { make: 'Mercedes', model: 'Maybach', price: 175720, electric: false, month: 'December' },
        { make: 'Vauxhall', model: 'Astra', price: 25795, electric: false, month: 'April' },
        { make: 'Fiat', model: 'Panda', price: 13724, electric: false, month: 'November' },
        { make: 'Jaguar', model: 'I-PACE', price: 69425, electric: true, month: 'May' },
    ]);*/
    
    const [rowData, setRowData] = useState([]);

    useEffect(() => {
        // Fetch data from your ASP.NET MVC controller
        fetch('/Car/GetData') // Adjust the URL as needed
            .then(response => response.json())
            .then(data => setRowData(data));
    }, []);
    

    const defaultColDef = useMemo(() => {
        return {
            editable: true,
            filter: true,
        };
    }, []);

    // Column Definitions: Defines the columns to be displayed.
    const [colDefs, setColDefs] = useState([
        { field: "make" },
        { field: "model" },
        { field: "price" },
        { field: "electric" },
        { field: "month" }
    ]);

    return (
        // wrapping container with theme & size
        <div
            className="ag-theme-quartz" // applying the Data Grid theme
            style={{ height: 600 }} // the Data Grid will fill the size of the parent container
        >
            <AgGridReact
                rowData={rowData}
                columnDefs={colDefs}
                defaultColDef={defaultColDef}
                pagination={true}
                paginationPageSize={10}
                paginationPageSizeSelector={[10, 25, 50]}
            />
        </div>
    );
};

export default AgDataGridEx;



