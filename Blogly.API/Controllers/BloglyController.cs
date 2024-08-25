using Blogly.Application.Interfaces;
using Blogly.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Blogly.Controllers;

[ApiController]
[Consumes("application/json")]
public class BloglyController(IBloglyService bloglyService) : ControllerBase
{
    [HttpPost(ApiEndpoints.ApplicationUser.CreateUser)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken token)
    {
        var response = await bloglyService.CreateNewUserAsync(request, token);

        if (response == null) return BadRequest();

        return CreatedAtAction("", new {id = response.Id}, response);
    }
    
    [HttpGet(ApiEndpoints.ApplicationUser.GetUsers)]
    public async Task<IActionResult> CreateBlog(CancellationToken token)
    {
        var response = await bloglyService.GetUsersAsync(token);

        return Ok(response);
    }
}