using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductReview
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }  // Clave foránea que relaciona la reseña con un producto.


        //public string ReviewerName { get; set; }
        public string Reviewer { get; set; }
        //public string ReviewText { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }

        // Propiedad de navegación de vuelta a Product
        public Product Product { get; set; }
    }
}
