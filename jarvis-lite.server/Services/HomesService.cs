using System;
using System.Collections.Generic;
using jarvis_lite.server.Models;
using jarvis_lite.server.Utilities.GenerateData;

namespace jarvis_lite.server.Services
{
    public class HomesService : IHomesService
    {
        private GenerateData _generateData = new GenerateData();

        public IList<House> GetHomes()
        {
            try
            {
                return _generateData.GetHomes();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to retrieve homes: {0}", e);
                throw;
            }
        }

        public House GetRoomValuesInHome(string houseId)
        {
            try
            {
                bool houseExists = _generateData.CheckIfHomeExists(houseId);

                if (!houseExists)
                {
                    return null;
                }

                House house = new House(houseId);
                house.Rooms = _generateData.GenerateValuesForRoomsInHome(houseId);

                return house;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read room values in home: {0}", e);
                throw;
            }
        }
    }
}