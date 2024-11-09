using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        //private static readonly List<Product> _products = new List<Product>();
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request,CancellationToken cancellationToken)
        {
            //return await Task.FromResult(_products.AsEnumerable());
            return await _productRepository.GetAllAsync();
        }
    }
}
