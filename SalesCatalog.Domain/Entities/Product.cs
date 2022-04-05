namespace SalesCatalog.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidateId(id);
            Validate(name, description, price, stock, image);

            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            Validate(name, description, price, stock, image);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            Validate(name, description, price, stock, image);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        private void Validate(string name, string description, decimal price, int stock, string image)
        {
            Validator.When(string.IsNullOrEmpty(name), "Name can't be null or empty");
            Validator.When(name.Length < 3, "Too short name, minimum 3 characters");

            Validator.When(string.IsNullOrEmpty(description), "Description can't be null or empty");
            Validator.When(description.Length < 5, "Too short description, minimum 5 characters");

            Validator.When(price < 0, "Invalid price value");

            Validator.When(stock < 0, "Invalid stock value");

            Validator.When(image?.Length > 250, "Too long image name, maximum 250 characters");
        }
    }
}
