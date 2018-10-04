import React, {Component} from 'react';
import {injectGlobal} from 'styled-components';

injectGlobal`
   body {
        margin: 0;
        padding: 0;
        background-color: #ffffff;
        font-family: "Open Sans", Helvetica;
        font-size: 14px;
   }
`;

class App extends Component {
    render() {
        return (
            <div className="App">
                <h1>Initial commit...</h1>
                <h2>Testing...</h2>
            </div>
        );
    }
}

export default App;
