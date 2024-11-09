using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddProductReview
{
    public record AddProductReviewCommand(Guid ProductId, string Reviewer, string Comment, int Rating) : IRequest<bool>;
}
