import React, {Component} from 'react';
import styled from 'styled-components';
import apiHomes from '../../api/apiHomes';

const HomeContainer = styled.div`
    width: 400px;
    height: fit-content;
    margin-top: 64px;
    margin-right: 32px;
    margin-bottom: 32px;    
    border: 1px solid #f2f2f2;
    text-align: center;
    user-select: none;
    
    @media screen and (max-width: 500px) {
        width: 300px;
        margin-right: 0px;
    }
`;

const ImageContainer = styled.img`
    height: 200px;
    width: 200px;  
`;

const Title = styled.h2`
    color: #CC0033;
    font-size: 20px;
    user-select: none;
    cursor: default;
`;

const Room = styled.ul`
`;

const RoomValue = styled.li`
    width: fit-content;
    font-size: 16px;
    list-style: none;
    user-select: none;
`;

class Home extends Component {
    constructor(props) {
        super(props);
        this.retrieveUpdatedRoomValuesFromServer = this.retrieveUpdatedRoomValuesFromServer.bind(this);
        this.state = {
            roomValues: null
        };
    }

    componentDidMount() {
        const id = this.props.id;
        if (!this.state.roomValues) {
            this.retrieveInitialRoomValuesFromServer(id);
        }
    };

    retrieveInitialRoomValuesFromServer = (id) => {
        try {
            apiHomes.getHomeData(id).then(response => {
                const initRoomValues = response.data.rooms;
                this.setState({roomValues: initRoomValues});

                // After initial values have been set it will then call this method which fetches updated values every 60 secs
                this.retrieveUpdatedRoomValuesFromServer(id);
            });
        } catch (e) {
            console.log('Failed to retrieve room values from server: ', e);
        }
    };

    async retrieveUpdatedRoomValuesFromServer(id) {
        try {
            setInterval(async () => {
                await apiHomes.getHomeData(id).then(response => {
                    const updatedRoomValues = response.data.rooms;
                    this.setState({roomValues: updatedRoomValues});
                })
            }, 60000);
        } catch (e) {
            console.log('Failed to retrieve updated room values from server: ', e);
        }
    };

    render() {
        let home = null;

        if (this.state.roomValues) {
            home = this.state.roomValues.map(h => {
                    return <Room key={h.name}>
                        <RoomValue>Room: {h.name}</RoomValue>
                        <RoomValue>Temperature: {h.temperature}°C</RoomValue>
                        <RoomValue>Humidity: {Math.floor(h.humidity * 100)}%</RoomValue>
                        <RoomValue>Date Retrieved: {h.date}</RoomValue>
                    </Room>
                }
            );
        }
        return (
            <HomeContainer>
                <ImageContainer src="/images/house_logo.png"/>
                <Title>{this.props.id}</Title>
                {home}
            </HomeContainer>
        );
    }
}

export default Home;