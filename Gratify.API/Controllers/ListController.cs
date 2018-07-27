using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gratify.API.Controllers
{
    [Route("api/lists")]
    public class ListsController : Controller
    {
        [HttpGet()]
        public JsonResult GetLists()
        {
            return new JsonResult(ListsDataStore.Current.Lists);
        }

        [HttpGet("{id}")]
        public JsonResult GetLists(int id)
        {
            return new JsonResult(ListsDataStore.Current.Lists.FirstOrDefault(l => l.Id == id));
        }

    }
}
