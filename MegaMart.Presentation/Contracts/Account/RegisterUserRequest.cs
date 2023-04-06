namespace MegaMart.Presentation.Contracts.Account
{
    public sealed record RegisterUserRequest(
        string Email,
        string Username,
        string Password,
        string ConfirmPassword);
}
