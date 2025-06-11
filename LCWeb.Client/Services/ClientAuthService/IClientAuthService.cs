using LCWeb.Client.Response;
using LCWeb.Shared.DTOs.AuthDTO;

namespace LCWeb.Client.Services.ClientAuthService
{
    public interface IClientAuthService
    {
        Token Token { get; set; }
        Task<string> LoginAsync(LoginDTO request);
        Task<string> RefreshToken();
        Task<int> Register(RegisterDTO request);
        Task<string> Logout();
        Task<int> ChangePassword(ChangePassDTO payload);
        Task<int> ForgotPass(ForgotPasswordDTO payload);
        Task<int> VerifyCode(VerifyCodeDTO payload);
        Task<EditProfileDTO?> GetSingleUser();
        Task<int> UpdateUser(EditProfileDTO request);
        Task<string> GetSingleUserAvatar();
    }
}
