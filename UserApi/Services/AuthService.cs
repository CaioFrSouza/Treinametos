using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthApi.Data;
using AuthApi.Helper;
using AuthApi.Services.Interfaces;
using DTOs;
using DTOs.Auth.Requests;
using DTOs.Auth.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AuthApi.Services;

public class AuthService:AuthServiceHelper, IAuthService
{
    private readonly UserManager<AuthUserModel> _userManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<AuthUserModel> userManager, IConfiguration configuration) : base(configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<BaseResponse<CreateNewUserResponseDTO>> CreateUser(CreateNewUserRequestDTO user)
    {
        var response = new BaseResponse<CreateNewUserResponseDTO>();
        var createUser = new AuthUserModel();
        createUser.UserName = user.Username.ToLower();
        createUser.Email = user.Email;
        var result =  await _userManager.CreateAsync(createUser, user.Password);
        if (!result.Succeeded)
        {
            response.AdicionarErro(result?.Errors?.First()?.Description ?? "");
            return response;
        }

        var userResponse = new CreateNewUserResponseDTO();
        userResponse.UserName = user.Username.ToLower();
        userResponse.Mensagem = "Usuario cadastrado com sucesso!";
        response.Data = userResponse;
        return response;
    }

    public async Task<GenerateJWTResponseDTO> LoginUser(LoginUserRequestDTO user)
    {
        var response = new GenerateJWTResponseDTO();
        var existUser = await _userManager.FindByEmailAsync(user.Email);
        if (existUser == null)
        {
            response.AddError("Usuario ou senha incorretos");
            return response;
        }
        var passwordCorrect = await _userManager.CheckPasswordAsync(existUser, user.Password);
        if (!passwordCorrect)
        {
            response.AddError("Usuario ou senha incorretos");
            return response;
        }

        var token = GenerateToken(existUser);
        response.AcessToken = new JwtSecurityTokenHandler().WriteToken(token);
        return response;
    }

}