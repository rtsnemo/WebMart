﻿using Application.Abstractions.Reviews;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Reviews.QueryHandlers
{
    public record GetReviewsByProduct(int productId) : IRequest<ICollection<Review>>;
    public class GetReviewsByProductHandler(IReviewRepository reviewRepository) : IRequestHandler<GetReviewsByProduct, ICollection<Review>>
    {
        private readonly IReviewRepository _reviewRepository = reviewRepository;

        public Task<ICollection<Review>> Handle(GetReviewsByProduct request, CancellationToken cancellationToken)
        {
            return _reviewRepository.GetReviewByProduct(request.productId);
        }
    }
}
