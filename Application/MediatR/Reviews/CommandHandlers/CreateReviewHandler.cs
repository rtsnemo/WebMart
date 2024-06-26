﻿using Application.Abstractions.Reviews;
using Application.MediatR.Reviews.Commands;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Reviews.CommandHandlers
{
    public class CreateReviewHandler : IRequestHandler<CreateReview, int>
    {
        private readonly IReviewRepository _context;

        public CreateReviewHandler(IReviewRepository context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReview command, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                Comment = command.Comment,
                UserID = command.UserId,
                ProductID = command.ProductId
            };

            _context.AddReview(review);

            return review.ReviewID;
        }
    }
}
