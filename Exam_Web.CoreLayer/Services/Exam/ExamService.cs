using Exam_Web.CoreLayer.DTOs.Questions;
using Exam_Web.CoreLayer.Services.Users;
using Exam_Web.DataLayer.Context;
using Exam_Web.DataLayer.Entities;

namespace Exam_Web.CoreLayer.Services.Exam
{
    public class ExamService : IExamService
    {
        private readonly ExamContext _context;
        private readonly IUserService _userService;

        public ExamService(ExamContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public List<TestQuestion> GetQuestionsByAzmoon(long AzmoonId)
        {
            return _context.Azmoons.Where(a => a.AzmoonId == AzmoonId).SelectMany(t => t.TestQuestions).ToList();


        }



        public async Task Import_Question_Answer_User(List<List<bool>> Answers, long Id_Azmoon, string Username)
        {

            var Questions = GetQuestionsByAzmoon(Id_Azmoon);
            var UserId = await _userService.GetIdByUserName(Username);



            foreach (var x in Answers.Select((answer, index) => (answer, index)))
            {
            
                _context.User_Azmoon_Test_Answers.Add(new User_Azmoon_Test_Answer()
                {
                    TestQuestionId = Questions[x.index].TestQuestionId,
                    AzmoonId = Id_Azmoon,
                    UserIdentityId = UserId,
                    Answer = Answers[x.index].FindIndex(y => y == true) + 1
                });

            }

            _context.SaveChanges();
            return;
        }

        public List<Azmoon> GetAllAzmoons()
        {
            return _context.Azmoons.ToList();
        }

        public TestQuestionFilterDto GetQuestionsByFilter(long AzmoonId, int Take, int PageId = 1)
        {
            if (PageId == 0)
            {
                PageId = 1;
            }
            var allquestions=_context.Azmoons.Where(a => a.AzmoonId == AzmoonId).SelectMany(t => t.TestQuestions);
            var skip = (PageId - 1) * Take;
            decimal x = allquestions.Count() / (decimal)Take;
            var pagecount = Math.Ceiling(x);
            return new TestQuestionFilterDto()
            {
               PageCount = (int)pagecount,
               Questions = allquestions.Skip(skip).Take(Take).ToList()
            };
        }
    }
}
