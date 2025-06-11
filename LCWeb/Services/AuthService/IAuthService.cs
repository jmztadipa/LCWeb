using LCWeb.Response;
using LCWeb.Shared.DTOs.AuthDTO;
using LCWeb.Shared.Models.Auth;

namespace LCWeb.Server.Services.AuthService
{
    public interface IAuthService 
    {
        Task<int> Register(RegisterDTO request);
        Task<LoginResponse> Login(LoginDTO request);
        Task<int> ForgotPass(ForgotPasswordDTO request);
        Task<int> VerifyCode(VerifyCodeDTO request);
        Task<LoginResponse?> ReRefreshToken(string? refToken);
        LoginResponse Logout();
        Task<int> ChangePassword(ChangePassDTO request);
        Task<int> UpdateUser(EditProfileDTO request);
        Task<EditProfileDTO?> GetSingleUser();
        Task<string> GetSingleUserAvatar();
    }
}
