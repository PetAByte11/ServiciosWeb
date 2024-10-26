using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _repository;

    public UsersController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberResponse>>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();

        return Ok(users);
    }
    
    [Authorize]
    [HttpGet("{id:int}")] //api/users/2
    public async Task<ActionResult<MemberResponse>> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null) return NotFound();

        return user;
    }

    [HttpGet("{username}")] // api/v1/users/Calamardo
    public async Task<ActionResult<AppUser>> GetByIdAsync(string username)
    {
        var user = await _repository.GetByUserNameAsync(username);

        if (user == null) return NotFound();

        return user;
    }

}
