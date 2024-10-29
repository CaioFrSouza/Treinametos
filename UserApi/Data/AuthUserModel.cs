using Microsoft.AspNetCore.Identity;

namespace AuthApi.Data;

public class AuthUserModel: IdentityUser
{
    public string FristName { get; set; }
    public string LastName { get; set; }
    
    // TODO ADD A TENANT
    
    public string TenantId { get; set; } = String.Empty;
    
    public string TenantName { get; set; } = String.Empty;
    
}