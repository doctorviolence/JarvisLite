using System.Collections.Generic;
using jarvis_lite.server.Models;
using jarvis_lite.server.Services;
using Microsoft.AspNetCore.Mvc;

namespace jarvis_lite.server.Controllers
{
    [Route("[controller]")]
    public class HomesController : Controller
    {
        private IHomesService _homeService = new HomesService();

        // GET /homes
        [HttpGet]
        public IList<House> GetHomes()
        {
            IList<House> homes = _homeService.GetHomes();
            if (homes == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            Response.StatusCode = 200;
            return homes;
        }

        // GET /homes/{id}/data
        [HttpGet("{id}/data")]
        public House GetHomeData(string id)
        {
            House home = _homeService.GetRoomValuesInHome(id);
            if (home == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            Response.StatusCode = 200;
            return home;
        }
    }
}