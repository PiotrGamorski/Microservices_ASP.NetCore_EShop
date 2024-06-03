namespace Ordering_Application.Dtos
{
    public record PaymentDto(
        string? CardName,
        string CardNumber,
        string Expiration,
        string CVV,
        int PaymentMethod);
}
