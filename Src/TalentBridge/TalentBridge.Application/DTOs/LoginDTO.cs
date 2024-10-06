namespace TalentBridge.Application.DTOs
{
    public class LoginDTO
    {
        public string Email { get; init;}
        public string Password { get; init; }
        public bool RememberMe { get; init; }
    }
}
