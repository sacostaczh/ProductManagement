using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces;

namespace Application.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        //private static readonly List<Product> _products = new();
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product
            {
                //Id = Guid.NewGuid(),  
                Name = request.Name,
                Price = request.Price,
            };

            //_products.Add(newProduct);
            //return await Task.FromResult(newProduct.Id);

            //return await _productRepository.AddAsync(newProduct);
            await _productRepository.AddAsync(newProduct);
            return newProduct.Id;
        }
    }
}
