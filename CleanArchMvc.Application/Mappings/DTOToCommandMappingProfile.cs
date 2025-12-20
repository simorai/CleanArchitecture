using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings
{
    /// <summary>
    /// AutoMapper profile for mapping between ProductDTO and product command objects.
    /// </summary>
    public class DTOToCommandMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DTOToCommandMappingProfile"/> class.
        /// Configures mappings between <see cref="ProductDTO"/> and product command types.
        /// </summary>
        public DTOToCommandMappingProfile()
        {
            /// <summary>
            /// Maps <see cref="ProductDTO"/> to <see cref="ProductCreateCommand"/> and vice versa.
            /// </summary>
            CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();

            /// <summary>
            /// Maps <see cref="ProductDTO"/> to <see cref="ProductUpdateCommand"/> and vice versa.
            /// </summary>
            CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();
        }
    }
}
