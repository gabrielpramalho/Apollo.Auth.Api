using Apollo.Auth.Api.Base.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Apollo.Auth.Api.Interface.Controllers;

public class UserController : BaseController
{

    public class UserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }


    [HttpGet]
    public IActionResult GetAll() => Accepted();

    [HttpPost]
    public IActionResult Post([FromBody] UserRequest user)
    {
        return Ok(user);
    }
}