using Blogly.Application.Interfaces;
using Blogly.Contracts.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogly.Controllers;

[Authorize]
[ApiController]
[Consumes("application/json")]
public class BloglyController(IBloglyService bloglyService) : ControllerBase
{
    [HttpPost(ApiEndpoints.ApplicationUser.CreateUser)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken token)
    {
        var response = await bloglyService.CreateNewUserAsync(request, token);

        if (response == null) return BadRequest();

        return CreatedAtAction("GetUser", new {id = response.Id}, response);
    }
    
    [HttpGet(ApiEndpoints.ApplicationUser.GetUsers)]
    public async Task<IActionResult> GetUsers(CancellationToken token)
    {
        var response = await bloglyService.GetUsersAsync(token);

        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.ApplicationUser.GetUser)]
    public async Task<IActionResult> GetUser([FromRoute] Guid id, CancellationToken token)
    {
        var response = await bloglyService.GetUserAsync(id, token);

        if (response is null) return NotFound();
        return Ok(response);
    }
    
    [Authorize(policy: "author_policy")]
    [HttpDelete(ApiEndpoints.ApplicationUser.DeleteUser)]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id, CancellationToken token)
    {
        var response = await bloglyService.DeleteUserAsync(id, token);

        if (response is false) return NotFound();
        return Ok(response);
    }
}