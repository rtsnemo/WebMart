using Application.Abstractions.Products;
using Application.Abstractions.Reviews;
using Application.DTO.Products;
using Application.DTO.Reviews;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Repositories
{
    public class ReviewRepository(ApplicationDbContext _context) : IReviewRepository
    {
        public async Task<Review> AddReview(Review command)
        {
            var review = new Review
            {
                Comment = command.Comment,
                UserID = command.UserID,
                ProductID = command.ProductID
            };

            _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task DeleteReview(int reviewId)
        {
            var review = _context.Reviews
                .FirstOrDefault(p => p.ReviewID== reviewId);

            if (review is null) return;

            _context.Reviews.Remove((Review)review);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Review>> GetAll()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetReviewById(int reviewId)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(x => x.ReviewID == reviewId);

            return review;
        }

        public async Task<ICollection<Review>> GetReviewByProduct(int productId)
        {
            return await _context.Reviews
                .Where(q => q.ProductID == productId)
                .Include(r => r.User).Include(t=> t.User.ProfileImage)
                .ToListAsync();
        }

        public async Task<Review> UpdateReview(int reviewId, ReviewDTO update)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(p => p.ReviewID == reviewId);

            if (review == null)
            {
                throw new KeyNotFoundException($"Review with ID {reviewId} not found.");
            }

            var updateProperties = typeof(ReviewDTO).GetProperties();

            foreach (var prop in updateProperties)
            {
                var newValue = prop.GetValue(update);

                // Если значение не null, применяем к объекту продукта
                if (newValue != null)
                {
                    var reviewProperty = typeof(Review).GetProperty(prop.Name);

                    if (reviewProperty != null)
                    {
                        reviewProperty.SetValue(review, newValue);
                    }
                }
            }

            await _context.SaveChangesAsync();

            return review;
        }
    }
}
