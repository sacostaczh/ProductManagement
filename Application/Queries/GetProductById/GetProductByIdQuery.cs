using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IRequest<Product>;
}
