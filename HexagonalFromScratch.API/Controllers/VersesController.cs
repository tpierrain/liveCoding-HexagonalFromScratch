using System.Collections.Generic;
using HexagonalFromScratch.Infra;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalFromScratch.API.Controllers
{
    [Route("api/[controller]")]
    public class VersesController : Controller
    {
        private readonly RequestVersesJsonAdapter _versesAdapter;

        public VersesController(RequestVersesJsonAdapter versesAdapter)
        {
            _versesAdapter = versesAdapter;
        }

        // GET api/verses
        [HttpGet]
        public string Get()
        {
            return _versesAdapter.AskPoetry();
            // return "Supa result";
        }
    }
}