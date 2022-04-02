using System;

namespace SalesCatalog.Domain.Validation
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message) : base(message)
        {

        }
    }
}
