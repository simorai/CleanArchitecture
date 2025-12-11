namespace CleanArchMvc.Domain.Entities
{
    /// <summary>
    /// Represents a product entity with properties and domain validation logic.
    /// </summary>
    public sealed class Product : Entity
    {
        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the product.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the price of the product.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets the available stock for the product.
        /// </summary>
        public int Stock { get; private set; }

        /// <summary>
        /// Gets the image URL or path for the product.
        /// </summary>
        public string Image { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="description">The description of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="stock">The available stock for the product.</param>
        /// <param name="image">The image URL or path for the product.</param>
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with an identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <param name="name">The name of the product.</param>
        /// <param name="description">The description of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="stock">The available stock for the product.</param>
        /// <param name="image">The image URL or path for the product.</param>
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            Domain.Validation.DomainExceptionValidation.When(id < 0, "Invalid Id. Id must be greater than zero.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        /// <summary>
        /// Updates the product properties and category.
        /// </summary>
        /// <param name="name">The new name of the product.</param>
        /// <param name="description">The new description of the product.</param>
        /// <param name="price">The new price of the product.</param>
        /// <param name="stock">The new available stock for the product.</param>
        /// <param name="image">The new image URL or path for the product.</param>
        /// <param name="categoryId">The new category identifier for the product.</param>
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        /// <summary>
        /// Validates the domain rules for the product properties.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="description">The description of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="stock">The available stock for the product.</param>
        /// <param name="image">The image URL or path for the product.</param>
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

        /// <summary>
        /// Gets or sets the category identifier for the product.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category associated with the product.
        /// </summary>
        public Category Category { get; set; }
    }
}
