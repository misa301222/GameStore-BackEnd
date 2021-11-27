using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models.Catalogo;
using GameStore.Models.BindingModel;
using GameStore.Models;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly GameStoreDBContext _context;

        public ReviewController(GameStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Review
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReview()
        {
            return await _context.Review.ToListAsync();
        }

        // GET: api/Review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Review.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        [HttpGet("GetReviewByProductId/{productId}")]
        public async Task<object> GetReviewByProductId(int productId)
        {
            var result = await _context.Review.ToListAsync();
            List<Review> reviewList = new List<Review>();
            foreach (var review in result) { 
                if(review.ProductId == productId)
                {
                    reviewList.Add(review);
                }
            }
            return reviewList;
        }

        // PUT: api/Review/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpGet("VerifyReview/{email}/{productId}")]
        public async Task<object> VerifyReview(string email, int productId)
        {
            var result = await _context.Review.ToListAsync();
            foreach (var review in result)
            {
                if (review.ProductId == productId && review.Email == email)
                {
                    return false;
                }
            }
            return true;
        }

        [HttpPost("UpdateUsefulCountReviewModel")]
        public async Task<object> UpdateReviewLike([FromBody] UpdateUsefulCountReviewModel model)
        {
            var currentReviewList = _context.Review.Where(x => x.ProductId == model.productId).ToList();
            foreach (var review in currentReviewList)
            {
                var reviewLike = _context.ReviewLike.Where(x => x.ReviewId == review.Id).ToListAsync();
                var usefulCountTotal = reviewLike.Result.Sum(x => x.LikeValue);
                review.UsefulCount = usefulCountTotal;
                await _context.SaveChangesAsync();
            }
            return await Task.FromResult(new ResponseModel(GameStore.Enums.ResponseCode.OK, "Useful Count updated!", null));
        }

        // POST: api/Review
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("SaveReview")]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _context.Review.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }

        // DELETE: api/Review/5
        [HttpDelete("DeleteReviewById/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Review.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }
    }
}
