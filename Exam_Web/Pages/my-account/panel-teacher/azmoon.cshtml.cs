using Exam_Web.CoreLayer.Services.Exam;
using Exam_Web.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exam_Web.Pages.my_account.panel_teacher
{

    [BindProperties]
    public class azmoonModel : PageModel
    {

        private readonly IExamService _examService;



        public List<Azmoon> All_Azmoon;


        public azmoonModel(IExamService examService)
        {
            _examService = examService;
        }

        public void OnGet()
        {

            All_Azmoon= _examService.GetAllAzmoons();




        }
    }
}
