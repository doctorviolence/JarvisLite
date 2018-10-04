using System;
using System.Collections.Generic;
using System.Linq;
using jarvis_lite.server.Models;

namespace jarvis_lite.server.Utilities.GenerateData
{
    public class GenerateData
    {
        private static Random _random = new Random();

        // Initializes static list of houses and rooms (kept in memory...)
        private static List<House> _houses = new List<House>()
        {
            new House()
            {
                HouseId = "hus1",
                Rooms = new List<Room> {new Room("Badrum"), new Room("Kök"), new Room("Vardagsrum")}
            },
            new House()
            {
                HouseId = "hus2",
                Rooms = new List<Room> {new Room("Källare"), new Room("Vind")}
            }
        };

        public List<House> GetHomes()
        {
            return _houses;
        }

        public bool CheckIfHomeExists(string houseId)
        {
            bool houseExists = _houses.Any(h => h.HouseId.Equals(houseId));
            return houseExists;
        }

        public List<Room> GenerateValuesForRoomsInHome(string houseId)
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            List<Room> rooms = new List<Room>();

            // Loops through _houses and if house exists then retrieves list of rooms
            foreach (var h in _houses)
            {
                if (h.HouseId.Equals(houseId))
                {
                    rooms = h.Rooms;
                }
            }

            // Loops through rooms and assigns random values, plus currentDate
            foreach (var r in rooms)
            {
                r.Temperature = GenerateRandomTemperatureReading();
                r.Humidity = GenerateRandomHumidityReading();
                r.Date = currentDate;
            }

            return rooms;
        }

        private static float GenerateRandomTemperatureReading()
        {
            double randomTemperature = _random.NextDouble() * (50 - 0) + 0; // Random value between 0-50
            return (float) Math.Round(randomTemperature, 2); // Returns float value rounded to nearest two decimals
        }

        private static float GenerateRandomHumidityReading()
        {
            double randomTemperature = _random.NextDouble() * (1 - 0) + 0; // Random value between 0-50
            return (float) Math.Round(randomTemperature, 2); // Returns float value rounded to nearest two decimals
        }
    }
}