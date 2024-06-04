using Application.Abstractions.Reviews;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Reviews.QueryHandlers
{
    public record GetAllReviews() : IRequest<ICollection<Review>>;
    public class GetAllReviewsHandler(IReviewRepository reviewRepository) : IRequestHandler<GetAllReviews, ICollection<Review>>
    {
        private readonly IReviewRepository _reviewRepository = reviewRepository;

        public Task<ICollection<Review>> Handle(GetAllReviews request, CancellationToken cancellationToken)
        {
            return _reviewRepository.GetAll();
        }
    }
}
