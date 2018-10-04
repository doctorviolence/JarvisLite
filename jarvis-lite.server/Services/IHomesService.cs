using System.Collections.Generic;
using jarvis_lite.server.Models;

namespace jarvis_lite.server.Services
{
    public interface IHomesService
    {
        IList<House> GetHomes();
        House GetRoomValuesInHome(string houseId);
    }
}