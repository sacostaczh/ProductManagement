using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        ////Colección ProductReview
        //public List<ProductReview> Reviews { get; private set; } = new();

        // Relación uno a muchos con ProductReview
        public List<ProductReview> Reviews { get; set; } = new List<ProductReview>();

        // Propiedad para manejar la concurrencia
        public byte[] RowVersion { get; set; }


        // Método para agregar una reseña (mantener la consistencia del agregado)
        public void AddReview(ProductReview review)
        {
            if (review == null)
            { 
                throw new ArgumentNullException(nameof(review));
            }

            Reviews.Add(review);  // Agrega una reseña a la lista de reseñas
        }

        // Método para eliminar una reseña
        public void RemoveReview(Guid reviewId)
        {
            var review = Reviews.FirstOrDefault(r => r.Id == reviewId);
            if (review == null)
                throw new InvalidOperationException("Reseña no se encuentra.");

            Reviews.Remove(review);
        }

        // Método para actualizar una reseña
        public void UpdateReview(Guid reviewId, string reviewer, string comment, int rating)
        {
            var review = Reviews.FirstOrDefault(r => r.Id == reviewId);
            if (review == null)
                throw new InvalidOperationException("Reseña no se encuentra.");

            // Actualización de los datos de la reseña
            review.Reviewer = reviewer;
            review.Comment = comment;
            review.Rating = rating;
        }

        ////Agregados 08112024
        //public Product(Guid id, string name, decimal price)
        //{
        //    Id = id;
        //    Name = name;
        //    Price = price;
        //}

        //// Método para actualizar la información del producto
        //public void UpdateProductInfo(string name, decimal price)
        //{
        //    Name = name;
        //    Price = price;
        //}





        // Método para añadir una reseña
        //public void AddReview(string reviewer, string comment, int rating)
        //{
        //    var review = new ProductReview(Guid.NewGuid(), reviewer, comment, rating);
        //    Reviews.Add(review);
        //}

        //public class ProductReview
        //{
        //    public Guid Id { get; private set; }
        //    public string Reviewer { get; private set; }
        //    public string Comment { get; private set; }
        //    public int Rating { get; private set; }

        //    public ProductReview(Guid id, string reviewer, string comment, int rating)
        //    {
        //        Id = id;
        //        Reviewer = reviewer;
        //        Comment = comment;
        //        Rating = rating;
        //    }
        //}
    }
}
