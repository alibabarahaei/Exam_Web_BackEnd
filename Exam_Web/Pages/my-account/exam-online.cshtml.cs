using Exam_Web.CoreLayer.DTOs.Questions;
using Exam_Web.CoreLayer.Services.Exam;
using Exam_Web.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exam_Web.Pages.my_account
{





    [BindProperties]
    public class exam_onlineModel : PageModel
    {

        private readonly IExamService _examService;


        public TestQuestionFilterDto QuestionList_Sender { get; set; }

        public long Id_Azmoon { get; set; }

        public List<List<bool>> AnswernList_Reciver { get; set; }

        public exam_onlineModel(IExamService examService)
        {

            AnswernList_Reciver = new List<List<bool>>()
            {
                new List<bool>() {false, false, false, false},
                new List<bool>() {false, false, false, false},
                new List<bool>() {false, false, false, false},
                new List<bool>() {false, false, false, false},
                new List<bool>() {false, false, false, false},
                new List<bool>() {false, false, false, false},
                new List<bool>() {false, false, false, false},
                new List<bool>() {false, false, false, false},
                new List<bool>() {false, false, false, false},
                new List<bool>() {false, false, false, false},

            };
            _examService = examService;



        }

        public void OnGet(int PageId,int IdAzmoon)
        {

            QuestionList_Sender = _examService.GetQuestionsByFilter(1,10, PageId);
            ViewData["IdAzmoon"] = 1;


        }

        public async Task OnPost()
        {

            await _examService.Import_Question_Answer_User(AnswernList_Reciver, Id_Azmoon, User.Identity.Name);

        }

    }
}
