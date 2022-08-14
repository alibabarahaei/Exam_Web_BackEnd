using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_Web.DataLayer.Entities;

namespace Exam_Web.CoreLayer.DTOs.Questions
{
    public class TestQuestionFilterDto
    {
        public List<TestQuestion> Questions { get; set; }
        public int PageCount{ get; set; }
}
}
