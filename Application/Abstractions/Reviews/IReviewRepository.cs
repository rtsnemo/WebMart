using Application.DTO.Reviews;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Reviews
{
    public interface IReviewRepository
    {
        Task<Review> AddReview(Review review);
        Task<ICollection<Review>> GetAll();

        Task<Review> GetReviewById(int reviewId);

        Task<ICollection<Review>> GetReviewByProduct(int productId);

        Task<Review> UpdateReview(int reviewId, ReviewDTO update);

        Task DeleteReview(int reviewId);
    }
}
