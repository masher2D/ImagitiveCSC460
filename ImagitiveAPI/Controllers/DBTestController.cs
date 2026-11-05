using ImagitiveAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Imagitive.API.Controllers;

[ApiController]
[Route("api/db")]
public class DatabaseTestController : ControllerBase
{
    private readonly AppDBContext _context;

    public DatabaseTestController(AppDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            _context.Database.OpenConnection();

            return Ok("Connection Successful");
        }
        catch (Exception ex)
        {
            return Ok(ex.Message);
        }
    }
}