using SalesCatalog.Domain.Validation;
using System.Collections.Generic;

namespace SalesCatalog.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            Validate(name);

            Name = name;
        }

        public Category(int id, string name)
        {
            ValidateId(id);
            Validate(name);

            Id = id;
            Name = name;
        }


        public ICollection<Product> Products { get; set; }
        
        public void Update(string name)
        {
            Validate(name);

            Name = name;
        }

        private void Validate(string name)
        {
            Validator.When(string.IsNullOrEmpty(name), "Name can't be null or empty");
            Validator.When(name.Length < 3, "Too short name, minimum 3 characters");
        }
    }
}
