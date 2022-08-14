using Exam_Web.CoreLayer.Services.Exam;
using Exam_Web.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exam_Web.Pages.my_account.panel_teacher
{


    [BindProperties]
    public class edit_azmoonModel : PageModel
    {


        private readonly IExamService _examService;


        public long? _idazmoon;
        public List<TestQuestion>? _questions;


        public edit_azmoonModel(IExamService examService)
        {
            _examService = examService;
        }


        
        public void OnGet()
        {
            var idazmoon = 1;
            _idazmoon = idazmoon;

        _questions = _examService.GetQuestionsByAzmoon(idazmoon);
        

        }
      
        public IActionResult OnGetdeletetest(long idazmoon1, long idtest)
        {
            var x = idazmoon1 + idtest;
            throw new Exception("sdada");
            RedirectToPage();
        }
    }
}
