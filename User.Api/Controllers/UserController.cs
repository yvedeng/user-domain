using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Contracts.User;

namespace User.Api.Controllers;

[Route("[controller]")]
public class UserController: ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public UserController(
        ISender mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPut("{id:guid}")]
    
    public async Task<IActionResult> UpdateUserAsync(
        Guid id, 
        UpdateUserRequest request)
    {
        return Ok(id);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUserAsync(Guid id)
    {
        return Ok(id);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserAsync(Guid id)
    {
        return Ok(id);
    }
}