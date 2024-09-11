/*
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
*/


import React from 'react';
import ReactDOM from 'react-dom';
import AgDataGridEx from './AgDataGridEx';
import RegisterForm from './RegisterForm';
//import RegisterFormMVC from './RegisterFormMVC';


if (document.getElementById('root')) 
   ReactDOM.render(<AgDataGridEx />, document.getElementById('root'));

// Render ComponentB if the corresponding root element is found
if (document.getElementById('register-root'))
    ReactDOM.render(<RegisterForm />, document.getElementById('register-root'));



