using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, decimal Price) : IRequest<bool>;
}
