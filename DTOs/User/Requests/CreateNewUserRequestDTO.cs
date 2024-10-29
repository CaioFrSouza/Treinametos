namespace DTOs.Auth.Requests;

public class CreateNewUserRequestDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string TenantId { get; set; }
    
    public string TenantName { get; set; }
}