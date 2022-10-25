using System;
using Microsoft.AspNetCore.Mvc;
using FuelStationBackend.Services;
using FuelStationBackend.Models;

namespace FuelStationBackend.Controllers;

[Controller]
[Route("api/[controller]")]
public class UserController : Controller
{

    private readonly UserService _userService;

    public UserController(UserService UserService)
    {
        _userService = UserService;
    }

    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await _userService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        await _userService.CreateAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }

}