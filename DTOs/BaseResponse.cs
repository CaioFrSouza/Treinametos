namespace DTOs;

public class BaseResponse<T>
{
    public bool Success { get; set; } = true;
    public T Data { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    public void AdicionarErro(string mensagem)
    {
        Success = false;
        Errors.Add(mensagem);
    }
}


