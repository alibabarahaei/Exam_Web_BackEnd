using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_Web.DataLayer.Context;
using Exam_Web.DataLayer.Entities;

namespace Exam_Web.CoreLayer.Services.Exam
{
    public class ExamService:IExamService
    {
        private readonly ExamContext _context;


        public ExamService(ExamContext context)
        {
            _context = context;
        }

        public void GetQuestionsByAzmoon(long AzmoonId)
        {
          //  return _context.Azmoons.Where(a => a.AzmoonId == AzmoonId).SelectMany(t => t.TestQuestions).ToList();

          
        }
    }
}
