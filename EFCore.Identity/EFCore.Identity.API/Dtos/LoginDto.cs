namespace EFCore.Identity.API.Dtos
{
    public record LoginDto(
        string UserNameOrEmail,
        string Password);
}
