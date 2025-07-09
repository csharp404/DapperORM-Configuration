using DapperORM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperORM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IUser user) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(string name)
        {
            var data = await user.CreateUserAsync(name);
            return Ok(data);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id , string name)
        {
            var data =  user.Update(id, name);
            return Ok(data);
        }


    }
}
