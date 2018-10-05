import React, {Component} from 'react';
import styled from 'styled-components';
import apiHomes from '../../api/apiHomes';

const HomeContainer = styled.div`
    height: 500px;
    width: 200px;
    margin-left: 20px;
    border: 1px solid #f2f2f2;
    user-select: none;
    
    @media screen and (max-width: 700px) {
        width: 20px;
        height: 250px;
        max-width: 200px;
        max-height: 200px;
    }
`;

const ImageContainer = styled.img`
    height: 200px;
    width: 200px;    
`;

const Title = styled.h2`
    color: #444444;
    font-size: 20px;
    user-select: none;
    cursor: default;
`;

const RoomValues = styled.div`
    margin-bottom: 40px;
    font-size: 14px;
    display: flex;
    text-align: left;
    border-bottom: 1px solid #bdbebf;
    align-items: center;
    user-select: none;
    
    @media screen and (max-width: 700px) {
        width: 80vw;
        font-size: 16px;
    }
`;

class Home extends Component {
    constructor(props) {
        super(props);
        this.retrieveRoomValuesFromServer = this.retrieveRoomValuesFromServer.bind(this);
        this.state = {
            roomValues: []
        };
    }

    componentDidMount() {
        const id = this.props.id;
        if (id) {
            this.retrieveRoomValuesFromServer(id);
        }
    };

    async retrieveRoomValuesFromServer(id) {
        try {
            setInterval(async () => {
                await apiHomes.getHomeData(id).then(response => {
                    const rooms = response.data.rooms;
                    this.setState({roomValues: rooms});
                })
            }, 5000);
        } catch (e) {
            console.log('Failed to retrieve room values from server: ', e);
        }
    };

    render() {
        let home = null;
        console.log('[Home.js] render method');

        if (this.state.roomValues) {
            home = this.state.roomValues.map(h => {
                    return <RoomValues key={h.name}>Room: {h.name} Temperature: {h.temperature} Humidity: {h.humidity} Date
                        Retrieve: {h.date}</RoomValues>
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