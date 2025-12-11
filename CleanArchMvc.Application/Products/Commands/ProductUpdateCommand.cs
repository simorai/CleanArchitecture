namespace CleanArchMvc.Application.Products.Commands
{
    /// <summary>
    /// Command to update an existing product.
    /// Inherits properties from <see cref="ProductCommand"/>.
    /// </summary>
    public class ProductUpdateCommand : ProductCommand
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product to update.
        /// </summary>
        public int Id { get; set; }
    }
}
