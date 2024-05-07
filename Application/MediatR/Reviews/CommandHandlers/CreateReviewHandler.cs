using Application.Abstractions.Reviews;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Reviews.CommandHandlers
{
    public record CreateReviewCommand(int Rating, string Comment, int UserId, int ProductId) : IRequest<int>;
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly IReviewRepository _context;

        public CreateReviewHandler(IReviewRepository context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReviewCommand command, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                Rating = command.Rating,
                Comment = command.Comment,
                UserID = command.UserId,
                ProductID = command.ProductId
            };

            _context.AddReview(review);

            return review.ReviewID; // Возвращаем ID созданного отзыва
        }
    }
    }
}
