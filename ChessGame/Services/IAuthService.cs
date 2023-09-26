using ChessGame.Models;


namespace ChessGame.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(LoginUser user);
        Task<bool> Login(LoginUser user);
        string GenerateTokenString(LoginUser user);
    }
}