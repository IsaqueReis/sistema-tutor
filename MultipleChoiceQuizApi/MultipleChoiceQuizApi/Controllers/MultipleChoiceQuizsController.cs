using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MultipleChoiceQuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultipleChoiceQuizsController : ControllerBase
    {
        private readonly MultipleChoiceQuizContext _context;

        public MultipleChoiceQuizsController(MultipleChoiceQuizContext context)
        {
            _context = context;
        }

        // GET: api/MultipleChoiceQuizs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MultipleChoiceQuiz>>> GetMultipleChoiceQuizzes()
        {
            return await _context.MultipleChoiceQuizzes.ToListAsync();
        }

        // GET: api/MultipleChoiceQuizs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MultipleChoiceQuiz>> GetMultipleChoiceQuiz(long id)
        {
            var multipleChoiceQuiz = await _context.MultipleChoiceQuizzes.FindAsync(id);

            if (multipleChoiceQuiz == null)
            {
                return NotFound();
            }

            return multipleChoiceQuiz;
        }

        // PUT: api/MultipleChoiceQuizs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultipleChoiceQuiz(long id, MultipleChoiceQuiz multipleChoiceQuiz)
        {
            if (id != multipleChoiceQuiz.QuizId)
            {
                return BadRequest();
            }

            _context.Entry(multipleChoiceQuiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultipleChoiceQuizExists(id))
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

        // POST: api/MultipleChoiceQuizs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MultipleChoiceQuiz>> PostMultipleChoiceQuiz(MultipleChoiceQuiz multipleChoiceQuiz)
        {
            _context.MultipleChoiceQuizzes.Add(multipleChoiceQuiz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMultipleChoiceQuiz", new { id = multipleChoiceQuiz.QuizId }, multipleChoiceQuiz);
        }

        // DELETE: api/MultipleChoiceQuizs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MultipleChoiceQuiz>> DeleteMultipleChoiceQuiz(long id)
        {
            var multipleChoiceQuiz = await _context.MultipleChoiceQuizzes.FindAsync(id);
            if (multipleChoiceQuiz == null)
            {
                return NotFound();
            }

            _context.MultipleChoiceQuizzes.Remove(multipleChoiceQuiz);
            await _context.SaveChangesAsync();

            return multipleChoiceQuiz;
        }

        private bool MultipleChoiceQuizExists(long id)
        {
            return _context.MultipleChoiceQuizzes.Any(e => e.QuizId == id);
        }
    }
}
