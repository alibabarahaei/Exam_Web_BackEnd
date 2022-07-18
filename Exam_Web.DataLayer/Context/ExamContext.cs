using Exam_Web.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Web.DataLayer.Context
{
    public class ExamContext:DbContext
    {
        public ExamContext(DbContextOptions<ExamContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<TestQuestion> TestQuestions { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }



    }
}
