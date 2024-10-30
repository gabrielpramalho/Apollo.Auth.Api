using Apollo.Auth.Api.Base.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Apollo.Auth.Api.Interface.Controllers;

public class LoginController : BaseController
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    [HttpPost]
    public IActionResult Post([FromBody] LoginRequest loginRequest)
    {
        return Ok( new { loginRequest.Email, loginRequest.Password } );
    }
}
