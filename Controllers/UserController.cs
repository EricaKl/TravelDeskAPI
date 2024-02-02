using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelDeskAPI.DataContext;
using TravelDeskAPI.IRepo;
using TravelDeskAPI.Models;

namespace TravelDeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public IActionResult GetById(int? id)
        {
            if(!id.HasValue)
            {
              
                return BadRequest();
            }
            else
            {
                var data = _repo.GetUserById(id.Value);
                if(data == null)
                {
                    return NotFound();

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
               
                user.IsActive = true;
                user.CreateBy = 3;
                _repo.AddUser(user);
                return Ok("Added successfully");
            }
        }

        [HttpPost]
        [Route("Update/{id}")]
        public IActionResult Update(User user, int id)
        {
           var data = _repo.UpdateUser(user, id);

            if(data==0)
            {
                return NotFound();
            }
            else
            {
                return Ok("Updated Successfully");
            }

        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            bool data = _repo.DeleteUser(id);
            if(data == false )
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet]
        [Route("GetRoles")]
        [AllowAnonymousAttribute]
        public IActionResult GetRoles()
        {
           var data =  _repo.GetRoles();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetManagers")]
        [AllowAnonymousAttribute]
        public IActionResult GetManagers()
        {
            var data = _repo.GetManagers();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetDepartments")]
        [AllowAnonymousAttribute]

        public IActionResult GetDepartments()
        {
            var data = _repo.GetDepartments();
            return Ok(data);    
        }
    }
}
