using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_Web.DataLayer.Entities;

namespace Exam_Web.CoreLayer.Services.Exam
{
    public interface IExamService
    {
        void GetQuestionsByAzmoon(long AzmoonId);
    }
}
