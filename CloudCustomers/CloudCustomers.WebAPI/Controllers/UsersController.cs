using System;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.WebAPI.Controllers;

public class UsersController: ControllerBase
{
    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get(){
        return Ok("all good");
    }

}
