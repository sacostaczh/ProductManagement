using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.AddProduct
{
    public record AddProductCommand(string Name, decimal Price) : IRequest<Guid>;
    
}
