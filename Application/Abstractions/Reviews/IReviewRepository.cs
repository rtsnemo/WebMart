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
        Task<ICollection<Review>> GetAll();

        Task<Review> GetReviewById(int reviewId);

        Task<Review> UpdateReview(int reviewId, ReviewDTO update);

        Task DeleteReview(int reviewId);
    }
}
