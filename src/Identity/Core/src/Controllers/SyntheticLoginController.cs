using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SyntheticLoginController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("Invalid user ID.");
        }

        string token = TokenManager.EncryptToken(userId + ":" + DateTime.UtcNow.AddMinutes(5));
        return Ok(new { token });
    }
}
