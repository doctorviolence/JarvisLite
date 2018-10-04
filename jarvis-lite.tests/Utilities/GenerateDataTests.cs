using System.Collections.Generic;
using jarvis_lite.server.Models;
using jarvis_lite.server.Utilities.GenerateData;
using Xunit;

namespace jarvis_lite.tests.Utilities

{
    public class GenerateDataTests
    {
        private readonly GenerateData _generateData;

        public GenerateDataTests()
        {
            _generateData = new GenerateData();
        }

        [Fact]
        public void TestThatGenerateDataIsNotNull()
        {
            Assert.NotNull(_generateData);
        }

        [Fact]
        public void TestThatHousesEqualsTwo()
        {
            IList<House> houses = _generateData.GetHomes();
            Assert.True(houses.Count == 2);
            Assert.False(houses.Count == 1);
        }

        [Fact]
        public void TestThatHomeDataIsCorrect()
        {
            IList<House> houses = _generateData.GetHomes();
            Assert.True(houses[0].HouseId.Equals("hus1"));
            Assert.True(houses[0].Rooms.Count == 3);
            Assert.True(houses[1].HouseId.Equals("hus2"));
            Assert.True(houses[1].Rooms.Count == 2);
        }

        [Fact]
        public void TestThatGeneratingRandomRoomValuesWorks()
        {
            IList<House> houses = _generateData.GetHomes();
            string houseId = houses[0].HouseId;
            string houseId2 = houses[1].HouseId;

            IList<Room> rooms = _generateData.GenerateValuesForRoomsInHome(houseId);
            Assert.False(rooms[0].Temperature.Equals(rooms[1].Temperature));
            Assert.False(rooms[0].Humidity.Equals(rooms[1].Humidity));

            IList<Room> rooms2 = _generateData.GenerateValuesForRoomsInHome(houseId2);
            Assert.False(rooms[0].Temperature.Equals(rooms2[0].Temperature));
            Assert.False(rooms[0].Humidity.Equals(rooms2[0].Humidity));
            Assert.False(rooms[1].Temperature.Equals(rooms2[1].Temperature));
            Assert.False(rooms[1].Humidity.Equals(rooms2[1].Humidity));
        }

        [Fact]
        public void TestThatHomesMappingBetweenHouseAndRoomsIsCorrect()
        {
            IList<House> houses = _generateData.GetHomes();
            IList<Room> rooms = houses[0].Rooms;
            IList<Room> rooms2 = houses[1].Rooms;

            Assert.True(rooms[0].Name.Equals("Badrum"));
            Assert.True(rooms[1].Name.Equals("Kök"));
            Assert.True(rooms[2].Name.Equals("Vardagsrum"));

            foreach (var r in rooms)
            {
                Assert.False(r.Name.Equals("Källare"));
                Assert.False(r.Name.Equals("Vind"));
            }

            Assert.True(rooms2[0].Name.Equals("Källare"));
            Assert.True(rooms2[1].Name.Equals("Vind"));

            foreach (var r in rooms2)
            {
                Assert.False(r.Name.Equals("Badrum"));
                Assert.False(r.Name.Equals("Kök"));
                Assert.False(r.Name.Equals("Vardagsrum"));
            }
        }
    }
}