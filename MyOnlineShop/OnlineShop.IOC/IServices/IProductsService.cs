using OnlineShop.Core.DTO.GenericDTO;
using OnlineShop.Core.DTO.ProductsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.IServices
{
    public interface IProductsService
    {
        Task<GridResultDTO<AllProductsDTO>> GetAllProductsAsync(int take, int skip);
        Task<AllProductsDTO> GetProductByIdAsync(string id);
        Task<string> CreateProductAsync(CreateProductDTO createProductDTO);
        Task<string> UpdateProductAsync(UpdateProductDTO updateProductDTO);

        GridResultDTO<ProductsToUser> GetFiltredProducts(FilterProductsDTO dTO,int skip,int take);
        List<ProductsToUser> GetPopularByVotes();
        List<PopularRatedProductsDTO> GetPopularByRates();
    }
}
