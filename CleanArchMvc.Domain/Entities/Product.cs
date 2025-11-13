namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            Domain.Validation.DomainExceptionValidation.When(id < 0, "Invalid Id. Id must be greater than zero.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            Domain.Validation.DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            Domain.Validation.DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            Domain.Validation.DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");

            Domain.Validation.DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters");

            Domain.Validation.DomainExceptionValidation.When(price < 0,
                "Invalid price value");

            Domain.Validation.DomainExceptionValidation.When(stock < 0,
                "Invalid stock value");

            Domain.Validation.DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image name, too long, maximum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
