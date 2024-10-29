using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

public abstract class BaseController: Controller
{
    public IActionResult CustomResponse<T>(BaseResponse<T> response)
    {
        if (response == null)
        {
            response.AdicionarErro("Ocorreu um erro ao gerar os dados.");
            return BadRequest(response);
        }

        if (response.Success == false)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}