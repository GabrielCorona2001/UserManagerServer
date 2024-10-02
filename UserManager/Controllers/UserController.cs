using Microsoft.AspNetCore.Mvc;
using UserManager.DTO.User;
using UserManager.Models;
using UserManager.Services.User;

namespace UserManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> CreateUser(UserCreationDTO UserCreationDTO)
        {
            var users = await _userInterface.CreateUser(UserCreationDTO);  
            return Ok(users);


        }
        [HttpGet("GetAllUsers")]

        public async Task<ActionResult<ResponseModel<List<UserModel>>>> GetAllUsers()
        {
            var users = await _userInterface.GetAllUsers();
            return Ok(users);


        }

        [HttpGet("GetUserByName")]

        public async Task<ActionResult<ResponseModel<UserModel>>> GetUserByName(string name)
        {
            var user = await _userInterface.GetUserByName(name);
            return Ok(user);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            var users = await _userInterface.UpdateUser(userUpdateDTO);
            return Ok(users);   

        }

        [HttpDelete("DeleteUser")]

        public async Task<ActionResult<ResponseModel<List<UserModel>>>> DeleteUser(int id)
        {
            var users = await _userInterface.DeleteUser(id);
            return Ok(users);
        }
    }
}
