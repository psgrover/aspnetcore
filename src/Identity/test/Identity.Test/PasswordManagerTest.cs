namespace Microsoft.AspNetCore.Identity.Test;

public class PasswordManagerTest
{
    [Fact]
    public void HashPassword_ShouldReturnValidHash()
    {
        string password = "securePassword123";
        string hashedPassword = PasswordManager.HashPassword(password);

        Assert.True(PasswordManager.VerifyPassword(password, hashedPassword));
    }
}
