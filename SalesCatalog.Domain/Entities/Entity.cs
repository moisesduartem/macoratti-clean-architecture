using SalesCatalog.Domain.Validation;

namespace SalesCatalog.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        protected DomainValidator Validator = new DomainValidator();

        protected void ValidateId(int id)
        {
            Validator.When(id < 0, "Invalid id value");
        }
    }
}
