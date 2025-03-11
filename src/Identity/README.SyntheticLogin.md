## Synthetic Login System

### Overview
The **Synthetic Login System** extends ASP.NET Core Identity by enabling seamless login to external applications using existing user credentials. This feature is designed for scenarios where users need to securely access a secondary system without manual authentication.

### Key Features
- **Secure Credential Handling:** Uses **bcrypt hashing** for password storage and **AES-256 encryption** for session tokens.
- **Synthetic Login Endpoint:** The `/api/synthetic-login` endpoint generates temporary session tokens for seamless redirection to external systems.
- **OWASP Compliance:** Follows best practices to prevent **XSS**, **CSRF**, and session hijacking vulnerabilities.
- **Infrastructure Support:** Includes Terraform, Docker, and Kubernetes setup for scalable deployment.

### File Locations
| Component             | Path                                              |
|-----------------------|---------------------------------------------------|
| **PasswordManager.cs** | `/Core/src/Services/PasswordManager.cs`            |
| **TokenManager.cs**    | `/Core/src/Services/TokenManager.cs`               |
| **SyntheticLoginController.cs** | `/Core/src/Controllers/SyntheticLoginController.cs` |
| **AuthMiddleware.cs**  | `/Core/src/Middleware/AuthMiddleware.cs`           |
| **LoggingService.cs**  | `/Core/src/Services/LoggingService.cs`             |
| **Dockerfile**         | `/Core/src/Infrastructure/Dockerfile.Identity`     |
| **main.tf** (Terraform)| `/Infrastructure/main.tf`                         |
| **Unit Tests**         | `/test/Identity.Test/PasswordManagerTest.cs`      |
| **Integration Tests**  | `/test/Identity.Test/SyntheticLoginTest.cs`       |

### Running the Synthetic Login System
**To build the application:**
```bash
dotnet build
```

**To run the Synthetic Login System in Docker:**
```bash
docker build -t identity-app -f Core/src/Infrastructure/Dockerfile.Identity .
docker run --rm -p 5000:5000 identity-app
```

**To run tests (recommended for Feather OpenAI's environment):**
```bash
docker run --rm identity-app dotnet test --filter FullyQualifiedName~Microsoft.AspNetCore.Identity
```

### Security Best Practices
Incorporate these security principles to ensure robust protection:
✅ **Environment Variables:** Secure encryption keys and secrets via environment variables.
✅ **SameSite Cookies:** Mitigate CSRF attacks with `SameSite=Strict` cookie settings.
✅ **Rate Limiting:** Implement rate limiting to prevent abuse on `/api/synthetic-login`.
✅ **Logging & Auditing:** Use the provided **LoggingService** to capture login attempts for audit purposes.

### Future Enhancements
- **Enhanced Token Expiry Management.**
- **Multi-Factor Authentication (MFA) Integration.**
- **Custom Role-Based Access Control (RBAC).**

