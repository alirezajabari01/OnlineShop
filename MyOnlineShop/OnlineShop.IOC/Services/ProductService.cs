using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.DTO.GenericDTO;
using OnlineShop.Core.DTO.ProductsDTO;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Infrastructor.Repositories.Base;
using OnlineShop.IOC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.IOC.Services
{
    public class ProductService : IProductsService
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<string> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            string outPut = "انجام نشد";
          
            createProductDTO.ShortLink = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 4);
            var mappedProduct = mapper.Map<Product>(createProductDTO);
            var ceatedResult = await repository.CreateAsync(mappedProduct);
            if (ceatedResult > 1)
            {
                outPut = "انجام شد";
            }
            return outPut;
        }

        public async Task<GridResultDTO<AllProductsDTO>> GetAllProductsAsync(int take, int skip)
        {
            var allProducts = await repository.GetAll()
                .Skip(skip).Take(take)
                .ToListAsync();

            var mappedToDTO = mapper.Map<List<AllProductsDTO>>(allProducts);

            return new GridResultDTO<AllProductsDTO>(mappedToDTO.Count, mappedToDTO);
        }

        public GridResultDTO<ProductsToUser>
            GetFiltredProducts(FilterProductsDTO dTO, int skip, int take)
        {
            var products = repository.GetAll();

            if (!string.IsNullOrEmpty(dTO.Name))
            {
                products = products.Where(q => q.Name.Contains(dTO.Name));
            }
            if (!string.IsNullOrEmpty(dTO.CategoryId))
            {
                products = products.Include
                    (t => t.product_Categories)
                    .Where(y => y.product_Categories.Any(t => t.CategoryId == dTO.CategoryId));
            }

            if (dTO.MinPrice > 0)
            {
                products = products.Where(r => r.Price >= dTO.MinPrice && r.Price <= dTO.MaxPrice);
            }

            switch (dTO.OrderByType)
            {
                case "جدید ترین":
                    products = products.OrderByDescending(s => s.CreateDate);
                    break;
                case "ارزان ترین":
                    products = products.OrderByDescending(s => s.Price);
                    break;
            }

            var mappedProduct = mapper.Map<List<ProductsToUser>>
                (products.Include(s => s.Comments)
                .Include(e => e.ProductVotes)
                .Include(r => r.product_Categories));

            mappedProduct = mappedProduct.Skip(skip).Take(take).ToList();

            return new GridResultDTO<ProductsToUser>(products.Count(), mappedProduct);
        }

        public List<PopularRatedProductsDTO> GetPopularByRates()
        {
            var products = repository.GetAll()
                .Include(r => r.ProductRates)
                .Where(r => r.ProductRates.Any());

            var mappedProducts = mapper.Map<List<PopularRatedProductsDTO>>(products);
            mappedProducts = mappedProducts.OrderByDescending(t => t.RatePercent).ToList();
            return mappedProducts;
        }

        public List<ProductsToUser> GetPopularByVotes()
        {
            var products = repository.GetAll()
                .Include(r => r.ProductVotes)
                .Where(y => y.ProductVotes.Any(t => t.Vote == true)).ToList();

            foreach (var item in products)
            {
                foreach (var pr in item.ProductRates)
                {

                }
            }

            var mappedProduct = mapper.Map<List<ProductsToUser>>(products);
            mappedProduct = mappedProduct.OrderByDescending(o => o.ProductVotes.Count).Take(6).ToList();

            return mappedProduct;
        }

        public async Task<AllProductsDTO> GetProductByIdAsync(string id)
        {
            var product = await repository.GetByIdAsync(id);
            return mapper.Map<AllProductsDTO>(product);
        }

        public async Task<string> UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            string outPut = "انجام نشد";

            var product = await repository.GetAll()
                .Include(s => s.product_Categories)
                .FirstOrDefaultAsync(s => s.Id == updateProductDTO.Id);

            if (product != null)
            {
                product.Price = updateProductDTO.Price;
                product.Inventory = updateProductDTO.Inventory;
                product.Name = updateProductDTO.Name;
                product.IsActive = updateProductDTO.IsActive;
                product.Picture = updateProductDTO.Picture.Name;
                product.product_Categories = updateProductDTO.CategoryIds
                    .Select(s => new Product_Category()
                    {
                        CategoryId = s
                    }).ToList();

                var updatedResult = await repository.UpdateAsync(product);
                if (updatedResult == 1)
                {
                    outPut = "انجام شد";
                }
            }

            return outPut;
        }
    }
}
