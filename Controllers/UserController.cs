using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelDeskAPI.DataContext;
using TravelDeskAPI.IRepo;
using TravelDeskAPI.Models;

namespace TravelDeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
      
        IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
           
                _repo = repo;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var data = _repo.GetAllUsers();
            if(data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);

            }

        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            if(id==0)
            {
                return NotFound();
            }
            else
            {
                var data = _repo.GetUserById(id);
                if(data == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(data);
                }
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                _repo.AddUser(user);
                return Ok("Added successfully");
            }
        }
    }
}
