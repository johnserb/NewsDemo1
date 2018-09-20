using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsDemo.Data;
using NewsDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsDemo.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<List<NewsListItemDto>> GetAsync()
        {
            var newsProvider = new HackerNewsProvider();

            return await newsProvider.List();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "this is not implemented";
        }

       
    }
}
