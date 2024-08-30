
import React from 'react';
import ReactDOM from 'react-dom';
import AgDataGridEx from './AgDataGridEx';

const App = () => {
    return (
        <div>
            <h1>Hello, React!</h1>
            <AgDataGridEx />
        </div>
    );
};

ReactDOM.render(<AgDataGridEx />, document.getElementById('root'));


