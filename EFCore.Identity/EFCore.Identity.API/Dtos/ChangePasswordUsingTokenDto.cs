namespace EFCore.Identity.API.Dtos
{
    public record ChangePasswordUsingTokenDto(
        string Email,
        string NewPassword,
        string Token);
}
