using DTOs;
using DTOs.Auth.Requests;
using DTOs.Auth.Responses;

namespace AuthApi.Services.Interfaces;

public interface IUserService
{
    Task<BaseResponse<ListUsersResponseDTO>> ListUsers(ListUsersRequestDTO requestDto);
}