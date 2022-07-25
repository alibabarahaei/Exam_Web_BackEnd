using Exam_Web.DataLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam_Web.DataLayer.Context
{
    public class ExamContext : IdentityDbContext<UserIdentity>

    {
        public ExamContext(DbContextOptions<ExamContext> options) : base(options)
        {

        }


        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<Azmoon> Azmoons { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Azmoon_Test_Answer>().HasKey(table => new
            {
                table.AzmoonId,
                table.TestQuestionId,
                table.UserIdentityId

            });



            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }



    }
}
