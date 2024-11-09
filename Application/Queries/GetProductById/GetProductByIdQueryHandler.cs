using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        //private static readonly List<Product> _products = new();
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        { 
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            //var product = _products.FirstOrDefault(p => p.Id == request.Id);
            //return await Task.FromResult(product);

            var product = await _productRepository.GetByIdAsync(request.Id);
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
