using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MultipleChoiceQuizApi
{
    [Table("mcquiz", Schema = "public")]
    public class MultipleChoiceQuiz
    {
        [Column("quizid")]
        public long QuizId { get; set; }

        [Column("jsondata")]
        public string JsonData { get; set; }
    }

    public class MultipleChoiceQuizContext : DbContext 
    {
        public DbSet<MultipleChoiceQuiz> MultipleChoiceQuizzes { get; set; }

        public MultipleChoiceQuizContext(DbContextOptions<MultipleChoiceQuizContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MultipleChoiceQuiz>()
                .HasNoKey();
        }

    }
}
