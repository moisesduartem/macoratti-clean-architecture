namespace SalesCatalog.Domain.Validation
{
    public class DomainValidator
    {
        public void When(bool hasError, string errorMessage)
        {
            if (hasError)
                throw new DomainValidationException(errorMessage);
        }
    }
}
