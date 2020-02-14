using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ReceitasWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitaController : ControllerBase
    {
        public ReceitaController()
        { }

        [HttpGet]
        public async Task GetAllAsync()
        { }

        [HttpPost]
        public async Task InsertAsync()
        { }

        [HttpPut("{id:guid}")]
        public async Task UpdateAsync()
        { }
    }

}
