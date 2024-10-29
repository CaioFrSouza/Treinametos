namespace DTOs.Auth.Requests;

public class ListUsersRequestDTO
{
    public string TenantId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}