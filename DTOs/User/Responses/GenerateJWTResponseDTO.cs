namespace DTOs.Auth.Responses;

public class GenerateJWTResponseDTO
{
    public bool Success { get; set; } = true;
    public List<string> Errors { get; set; } = new List<string>();
    public string AcessToken { get; set; }
    public string RefreshToken { get; set; }

    public void AddError(string error)
    {
        Success = false;
        Errors.Add(error);
    }
}