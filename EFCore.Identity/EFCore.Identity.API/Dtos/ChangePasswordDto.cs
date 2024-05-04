namespace EFCore.Identity.API.Dtos
{
    public record ChangePasswordDto(Guid Id, string CurrentPassword, string NewPassword);
}
