namespace DTOs.Auth.Responses;

public class ListUsersResponseDTO
{
    public List<ListUsersItem> ListUsers { get; set; } = new List<ListUsersItem>();
}


public class ListUsersItem
{
    public string Name { get; set; }
    public string Id { get; set; }
    public string Email { get; set; }
    public string TenantName { get; set; }
    public string TenantId { get; set; }
}