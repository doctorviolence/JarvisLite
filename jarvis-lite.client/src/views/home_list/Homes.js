import React, {Component} from 'react';
import styled from 'styled-components';
import Home from '../../components/home/Home';
import apiHomes from '../../api/apiHomes';

const Container = styled.div`
    justify-content: space-between;
    align-items: center;
    display: flex;
    flex-direction: column;
    animation: 'slideIn' 0.5s ease-in-out;
    transition: all 0.5s ease-in-out;
   
    @keyframes slideIn {
        0% {
            transform: translateX(-20vw);
        }
    }
`;

const Title = styled.h2`
    margin-bottom: 50px;
    color: #444444;
    font-size: 36px;
    user-select: none;
    cursor: default;
    
    @media screen and (max-width: 700px) {
        font-size: 20px;
    }
`;

const Content = styled.div`
    display: flex;
`;

class Homes extends Component {
    state = {
        homes: [],
    };

    componentDidMount() {
        apiHomes.getHomes().then(response => {
            const homes = response.data;
            const data = homes.map(home => {
                return {
                    ...home
                }
            });
            this.setState({homes: data});
        })
    };

    render() {
        const {homes} = this.state;

        return (
            <Container>
                <Title>Welcome to Jarvis Lite</Title>
                <Content>
                    {homes.map(h => {
                        return <Home
                            key={h.houseId}
                            id={h.houseId}/>
                    })}
                </Content>
            </Container>
        );
    };
}

export default Homes;