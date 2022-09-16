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

        
        public long? _idazmoon { get; set; }
        public List<TestQuestion>? _questions { get; set; }
        

        public edit_azmoonModel(IExamService examService)
        {
            _examService = examService;
        }


        
        public void OnGet()
        {
            var idazmoon = 2;
            _idazmoon = idazmoon;

        _questions = _examService.GetQuestionsByAzmoon(idazmoon);
        

        }
      
        public IActionResult OnGetDeletetest(int id)
        {
            
            throw new Exception("sdada");
            RedirectToPage();
        }
    }

    
}
