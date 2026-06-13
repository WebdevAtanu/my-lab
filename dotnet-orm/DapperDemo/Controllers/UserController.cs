using DapperDemo.Models;
using DapperDemo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repository.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _repository.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _repository.Create(user);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _repository.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}