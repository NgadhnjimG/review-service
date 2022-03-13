using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewService;
using ReviewService.Helpers;
using ReviewService.Models;

namespace ReviewService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarReviewsController : ControllerBase
    {
        private readonly KomentDBContext dbConnection;

        public StarReviewsController(KomentDBContext context)
        {
            dbConnection = context;
        }

        // GET: api/StarReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseReviewDataObject>>> GetStarReview()
        {
            var reviews=new List <CourseReviewDataObject>();
            var course = this.dbConnection.Course.ToList();
            foreach (var crs in course) {
                var specificreview= new CourseReviewDataObject();

                var reviewslist = this.dbConnection.StarReview.Where(x => x.CourseId == crs.ID).ToList();
                var count = reviewslist.Count;
                if (count == 0) count = 1;
                var sum = 0.0;
                foreach (var rev in reviewslist)
                {
                    sum = sum + rev.Review;

                }
                double finalrev = sum / count;

                specificreview.CourseId = crs.ID;
                specificreview.StarReview = finalrev;
                var commentsClass = this.dbConnection.Comments.Where(x => x.CourseId == crs.ID).ToList();
                foreach (var com in commentsClass)
                {
                    specificreview.Comments.Add(com.CommentContent);
                }
                reviews.Add(specificreview);
            }


            return reviews;
        }

        // GET: api/StarReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StarReview>> GetStarReview(int id)
        {
            var starReview = await dbConnection.StarReview.FindAsync(id);

            if (starReview == null)
            {
                return NotFound();
            }

            return starReview;
        }

        // PUT: api/StarReviews/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStarReview(int id, StarReview starReview)
        {
            if (id != starReview.ID)
            {
                return BadRequest();
            }

            dbConnection.Entry(starReview).State = EntityState.Modified;

            try
            {
                await dbConnection.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarReviewExists(id))
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

        // POST: api/StarReviews
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<bool>> PostStarReview(ReviewHelper reviewHelper)
        {
            StarReview star = new StarReview();
            star.CourseId = reviewHelper.CourseId;
            star.Review = reviewHelper.StarRate;
            star.CreatedAt = DateTime.Now;
            star.UserId = 1; 
            dbConnection.StarReview.Add(star);

            Comment comment = new Comment();
            comment.CreatedAt = DateTime.Now;
            comment.CourseId = reviewHelper.CourseId;
            comment.UserId = 1;
            comment.CommentContent = reviewHelper.Comment;
            dbConnection.Comments.Add(comment);
            await dbConnection.SaveChangesAsync();

            return true;
        }

        // DELETE: api/StarReviews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StarReview>> DeleteStarReview(int id)
        {
            var starReview = await dbConnection.StarReview.FindAsync(id);
            if (starReview == null)
            {
                return NotFound();
            }

            dbConnection.StarReview.Remove(starReview);
            await dbConnection.SaveChangesAsync();

            return starReview;
        }

        private bool StarReviewExists(int id)
        {
            return dbConnection.StarReview.Any(e => e.ID == id);
        }
    }
}
