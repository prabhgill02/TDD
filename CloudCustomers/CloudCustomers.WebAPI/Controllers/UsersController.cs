using System;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.WebAPI.Controllers;

public class UsersController: ControllerBase
{
    private readonly IUsersService _usersService;
    public UsersController(IUsersService usersService) {
        this._usersService = usersService;
    }


    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get(){
        var users = await _usersService.GetAllUsers();

        if(users.Any()){
            return Ok(users);
        }
        return NotFound();
    }

}
