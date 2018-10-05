import React, {Component} from 'react';
import styled from 'styled-components';
import Home from '../../components/home/Home';
import apiHomes from '../../api/apiHomes';

const Container = styled.div`
    justify-content: space-between;
    align-items: center;
    display: flex;
    flex-direction: column;
    animation: 'slideIn' 0.3s ease-in-out;
    transition: all 0.3s ease-in-out;
   
    @keyframes slideIn {
        0% {
            transform: translateX(-20vw);
        }
    }
`;

const MenuContainer = styled.div`
    position: fixed;    
    width: 100%;
    background: #ffffff;
    text-align: center;
`;

const Title = styled.h1`
    color: #444444;
    font-size: 36px;
    user-select: none;
    cursor: default;
    
    @media screen and (max-width: 700px) {
        font-size: 20px;
    }
`;

const Subtitle = styled.h2`
    color: #CC0033;
    font-size: 16px;
    user-select: none;

    @media screen and (max-width: 500px) {
        font-size: 12px;
    }    
`;

const Content = styled.header`
    height: 600px;
    margin-top: 128px;    
    display: flex;
    flex-wrap: wrap;
    overflow: auto;    
    
    @media screen and (max-width: 500px) {
        width: 320px;
    }
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
                <MenuContainer>
                    <Title>Welcome to Jarvis Lite</Title>
                    <Subtitle>Your own personal Home Automation System. Data from your homes will be updated for you
                        here every minute.</Subtitle>
                </MenuContainer>
                <Content>
                    {homes.map(h => {
                        return <Home key={h.houseId} id={h.houseId}/>
                    })}
                </Content>
            </Container>
        );
    };
}

export default Homes;