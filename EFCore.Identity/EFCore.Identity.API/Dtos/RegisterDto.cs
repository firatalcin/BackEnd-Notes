namespace EFCore.Identity.API.Dtos
{
    public record RegisterDto(
        string Email, 
        string UserName,
        string FirstName,
        string LastName,
        string Password
        );
}
