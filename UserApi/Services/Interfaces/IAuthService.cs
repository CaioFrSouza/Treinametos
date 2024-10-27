using DTOs;
using DTOs.Auth.Requests;
using DTOs.Auth.Responses;

namespace AuthApi.Services.Interfaces;

public interface IAuthService
{
    Task<BaseResponse<CreateNewUserResponseDTO>> CreateUser(CreateNewUserRequestDTO user);
    Task<GenerateJWTResponseDTO> LoginUser(LoginUserRequestDTO user);
}