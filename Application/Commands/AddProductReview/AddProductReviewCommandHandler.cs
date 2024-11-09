using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Application.Commands.AddProductReview
{
    public class AddProductReviewCommandHandler : IRequestHandler<AddProductReviewCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public AddProductReviewCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(AddProductReviewCommand request, CancellationToken cancellationToken)
        {
            // Obtener el producto por su ID
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                Console.WriteLine($"Producto con ID {request.ProductId} no encontrado.");
                return false;
            }
            //Console.WriteLine($"Producto con ID {request.ProductId} no encontrado.");
            ////return false;

            // Crear la nueva reseña
            var review = new ProductReview
            {
                Id = Guid.NewGuid(),  // Genera un nuevo Id para la reseña
                Reviewer = request.Reviewer,
                Comment = request.Comment,
                Rating = request.Rating,
                ProductId = product.Id // Relacionar la reseña con el producto
            };

            //product.AddReview(request.Reviewer, request.Comment, request.Rating);
            // Agregar la reseña al producto (agregado)
            product.AddReview(review);

            //try
            //{
            //    return await _productRepository.UpdateAsync(product);
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    // Loguear o notificar al usuario del conflicto
            //    Console.WriteLine("Conflicto de concurrencia detectado. Intenta nuevamente.");
            //    return false;
            //}

            //_productRepository.Update(product); // Marca como modificado
            //var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            //return result > 0;

            // Guardar los cambios en la base de datos
            return await _productRepository.UpdateAsync(product);
        }
    }
}
