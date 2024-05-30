namespace Ordering_Domain.ValueObjects
{
    public record OrderName
    {
        private const int DefaultLength = 5;
        public string Value { get; }
        private OrderName(string value) => Value = value;
        private static OrderName Of(string value)
        { 
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            ArgumentOutOfRangeException.ThrowIfEqual(value.Length, DefaultLength);

            return new OrderName(value);
        }
    }
}
