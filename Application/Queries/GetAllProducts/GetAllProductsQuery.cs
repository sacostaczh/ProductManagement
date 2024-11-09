using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Queries.GetAllProducts
{
    public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;
    //public record GetAllProductsQuery() : IRequest<Product>;
}
