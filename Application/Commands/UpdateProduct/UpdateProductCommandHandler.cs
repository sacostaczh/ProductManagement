using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        { 
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                return false; //El producto no existe
            }

            // Recargar la entidad para asegurarse de que está sincronizada con la base de datos
            await _productRepository.ReloadAsync(product);

            product.Name = request.Name;
            product.Price = request.Price;

            return await _productRepository.UpdateAsync(product);
        }
    }
}
