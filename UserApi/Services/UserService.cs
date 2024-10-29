using AuthApi.Data;
using AuthApi.Services.Interfaces;
using DTOs;
using DTOs.Auth.Requests;
using DTOs.Auth.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Services;

public class UserService : IUserService
{
    private readonly UserManager<AuthUserModel> _userManager;
    private readonly IConfiguration _configuration;

    public UserService(UserManager<AuthUserModel> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<BaseResponse<ListUsersResponseDTO>> ListUsers(ListUsersRequestDTO dto)
    {
        var users = await _userManager.Users
            .Where(e => e.FristName.Contains(dto.Name) || e.LastName.Contains(dto.Name))
            .ToListAsync();

        var response = new BaseResponse<ListUsersResponseDTO>();
        response.Data = new ListUsersResponseDTO();
        
        if (users.Count == 0)
        {
            response.AdicionarErro("Não há usuarios cadastrados");
            return response;
        }

        for (int i = 0; i < users.Count; i++)
        {
            var userItem = new ListUsersItem();
            var user = users[i];
            userItem.Name = $"{user.FristName} {user.LastName}";
            userItem.TenantName = user.TenantName ?? user.TenantId;
            userItem.Email = user.Email ?? "";
            userItem.Id = user.Id ?? "";
            userItem.TenantId = user.TenantId ?? "";
            
            response.Data.ListUsers.Add(userItem);
        }

        return response;
    }
}
