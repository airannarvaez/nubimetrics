using Microsoft.AspNetCore.Mvc;
using Nubimetrics.Common.Models;
using Nubimetrics.Repositories;

namespace Nubimetrics.WebApi.Controllers
{
    [Route("usuarios")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(ILogger<UsersController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            _unitOfWork.Users.Add(user);
            await _unitOfWork.Complete();
            return Created("/usuarios/" + user.Id, user);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _unitOfWork.Users.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user == null)
                return BadRequest();

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.Complete();

            return NoContent();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var oldUser = _unitOfWork.Users.GetById(user.Id);
            if (oldUser == null)
                return BadRequest();

            var userEdited = _unitOfWork.Users.UpdateUser(user);
            await _unitOfWork.Complete();

            return Ok(userEdited);
        }

    }
}
