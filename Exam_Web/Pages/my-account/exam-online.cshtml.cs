using Exam_Web.CoreLayer.Services.Exam;
using Exam_Web.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exam_Web.Pages.my_account
{
    public class exam_onlineModel : PageModel
    {

        private readonly IExamService _examService;


        public List<TestQuestion> QuestionList;



        public exam_onlineModel(IExamService examService)
        {
            _examService = examService;
        }

        public void OnGet()
        {
            // QuestionList=_examService.GetQuestionsByAzmoon(1);
        }
    }
}
