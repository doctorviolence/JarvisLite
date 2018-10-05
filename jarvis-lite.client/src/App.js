import React, {Component} from 'react';
import {injectGlobal} from 'styled-components';
import Homes from './views/home_list/Homes';

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
                <Homes/>
            </div>
        );
    }
}

export default App;
