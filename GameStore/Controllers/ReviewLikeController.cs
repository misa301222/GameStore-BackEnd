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
    public class ReviewLikeController : ControllerBase
    {
        private readonly GameStoreDBContext _context;

        public ReviewLikeController(GameStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ReviewLike
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewLike>>> GetReviewLike()
        {
            return await _context.ReviewLike.ToListAsync();
        }

        // GET: api/ReviewLike/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewLike>> GetReviewLike(int id)
        {
            var reviewLike = await _context.ReviewLike.FindAsync(id);

            if (reviewLike == null)
            {
                return NotFound();
            }

            return reviewLike;
        }

        [HttpGet("VerifyLike/{email}/{reviewId}")]
        public async Task<object> VerifyLike(string email, int reviewId)
        {
            var result = await _context.ReviewLike.ToListAsync();
            foreach (var reviewLike in result)
            {
                if (reviewLike.Email == email && reviewLike.ReviewId == reviewId)
                {
                    return false;
                }
            }
            return true;
        }


        [HttpGet("GetLikesByEmailAndReviewId/{email}/{reviewId}")]
        public async Task<object> GetLikesByEmailAndReviewId(string email, int reviewId)
        {
            try
            {
                var result = await _context.ReviewLike.Where(x => x.Email == email).ToListAsync();
                return result;
            } catch (Exception ex)
            {
                return null;
            }            
        }



        // PUT: api/ReviewLike/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewLike(int id, ReviewLike reviewLike)
        {
            if (id != reviewLike.Id)
            {
                return BadRequest();
            }

            _context.Entry(reviewLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewLikeExists(id))
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

        // POST: api/ReviewLike
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("SaveLike")]
        public async Task<ActionResult<ReviewLike>> PostReviewLike(ReviewLike reviewLike)
        {
            _context.ReviewLike.Add(reviewLike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReviewLike", new { id = reviewLike.Id }, reviewLike);
        }

        [HttpPost("UpdateReviewLike")]
        public async Task<object> UpdateReviewLike([FromBody] UpdateLikeValueReviewLikeModel model)
        {
            var currentReviewLike = _context.ReviewLike.Where(x => x.ReviewId == model.ReviewId && x.Email == model.Email).SingleAsync();
            var newValue = model.LikeValue;
            currentReviewLike.Result.LikeValue = newValue;
            await _context.SaveChangesAsync();

            return await Task.FromResult(new ResponseModel(GameStore.Enums.ResponseCode.OK, "ReviewLike updated successfully!", null));
        }

        // DELETE: api/ReviewLike/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewLike(int id)
        {
            var reviewLike = await _context.ReviewLike.FindAsync(id);
            if (reviewLike == null)
            {
                return NotFound();
            }

            _context.ReviewLike.Remove(reviewLike);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteAllReviewLikeByReviewId/{reviewId}")]
        public async Task<IActionResult> DeleteAllReviewLikeByReviewId(int reviewId)
        {
            var listReviewLike = _context.ReviewLike.Where(x => x.ReviewId == reviewId).ToList();
            foreach (var reviewLike in listReviewLike)
            {
                if (reviewLike.ReviewId == reviewId)
                {
                    _context.Remove(reviewLike);
                    await _context.SaveChangesAsync();
                }
            }
            return NoContent();
        }

        private bool ReviewLikeExists(int id)
        {
            return _context.ReviewLike.Any(e => e.Id == id);
        }
    }
}
