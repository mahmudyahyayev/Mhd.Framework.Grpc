using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Grpc.Server
{
    public class ProductService : Product.ProductBase
    {

        public override async Task<GetProductResponse> Unary_GetProductByName(GetProductValidationRequest request, ServerCallContext context)
        {
            var product = ProductDto.Products.SingleOrDefault(u => u.Name == request.Name);

            if (product == null)
                throw new Exception("Product not found");

            return new GetProductResponse
            {
                Description = product.Desciption,
                Name = product.Name,
                ProductId = product.Id.ToString()
            };
        }

        public override async Task<GetProductResponse> Unary_GetProductById(GetProductRequest request, ServerCallContext context)
        {
            var product = ProductDto.Products.SingleOrDefault(u => u.Id == request._ProductId);

            if (product == null)
                throw new Exception("Product not found");

            return new GetProductResponse
            {
                Description = product.Desciption,
                Name = product.Name,
                ProductId = product.Id.ToString()
            };
        }
    }

    public class ProductDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Desciption { get; set; }

        public static IEnumerable<ProductDto> Products => new List<ProductDto>
        {
            new ProductDto{ Id = new Guid("7553088d-e89a-4c5a-f078-08d9fb519eab"), Desciption = "Product1 Description", Name = "Product1"},
            new ProductDto{ Id = new Guid("6a0f693f-e210-4d1c-f07b-08d9fb519eab"), Desciption = "Product2 Description", Name = "Product2"},
            new ProductDto{ Id = new Guid("cd17e187-d604-4057-f085-08d9fb519eab"), Desciption = "Product3 Description", Name = "Product3"},
            new ProductDto{ Id = new Guid("a68e31a2-1882-4ff8-f089-08d9fb519eab"), Desciption = "Product4 Description", Name = "Product4"},
            new ProductDto{ Id = new Guid("7fdf8540-6f1b-4cb4-f08d-08d9fb519eab"), Desciption = "Product5 Description", Name = "Product5"}
        };
    }
}
