
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace Microsoft.AspNetCore.Identity.Test;

public class SyntheticLoginTests
{
    [Fact]
    public void Login_ValidUserId_ReturnsToken()
    {
        var controller = new SyntheticLoginController();
        var result = controller.Login("validUser") as OkObjectResult;

        Assert.NotNull(result);
        Assert.Contains("token", result.Value.ToString());
    }
}
