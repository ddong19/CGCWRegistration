import React, {
    useMemo,
    useEffect,
    useState
} from "react";
import { AgGridReact } from 'ag-grid-react';
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-quartz.css";

const AgDataGridEx = () => {
    console.log('AgDataGridEx is being rendered');

    const [rowData, setRowData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch('/users/list')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                console.log('Fetched data: ', data);
                setRowData(data);
                setLoading(false);
            })
            .catch(err => {
                console.error('Fetch error:', err);
                setError('Failed to load data.');
                setLoading(false);
            });
    }, []);

    const defaultColDef = useMemo(() => {
        return {
            editable: false,
            filter: true,
        };
    }, []);

    const colDefs = useMemo(() => [
        { headerName: "First Name", field: "FirstName" },
        { headerName: "Last Name", field: "LastName" },
        { headerName: "Sex", field: "Sex" },
        { headerName: "Email", field: "Email" }
    ], []);

    const onGridReady = params => {
        params.api.sizeColumnsToFit();
    };

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }

    if (rowData.length === 0) {
        return <div>No Users</div>;
    }

    return (
        <div
            className="ag-theme-quartz"
            style={{ height: 600, width: '100%' }}
        >
            <AgGridReact
                rowData={rowData}
                columnDefs={colDefs}
                defaultColDef={defaultColDef}
                pagination={true}
                paginationPageSize={10}
                paginationPageSizeSelector={[10, 25, 50]}
                onGridReady={onGridReady}
            />
        </div>
    );
};

export default AgDataGridEx;
