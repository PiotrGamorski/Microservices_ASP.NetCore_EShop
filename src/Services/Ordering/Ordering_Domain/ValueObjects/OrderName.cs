﻿namespace Ordering_Domain.ValueObjects
{
    public record OrderName
    {
        private const int DefaultLength = 15;
        public string Value { get; }
        private OrderName(string value) => Value = value;
        public static OrderName Of(string value)
        { 
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Length, DefaultLength);

            return new OrderName(value);
        }
    }
}
