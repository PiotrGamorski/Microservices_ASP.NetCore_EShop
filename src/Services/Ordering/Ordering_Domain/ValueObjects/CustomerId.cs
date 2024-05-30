namespace Ordering_Domain.ValueObjects
{
    public record CustomerId
    {
        public Guid Id { get; }
        private CustomerId(Guid value) => Id = value;

        public static CustomerId Of(Guid value)
        { 
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            if (value == Guid.Empty)
            {
                throw new DomainException("CustomerId cannot be empty.");
            }

            return new CustomerId(value);
        }
    }
}
