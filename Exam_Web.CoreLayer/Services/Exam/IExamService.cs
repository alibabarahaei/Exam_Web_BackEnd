using Exam_Web.DataLayer.Entities;

namespace Exam_Web.CoreLayer.Services.Exam
{
    public interface IExamService
    {
        List<TestQuestion> GetQuestionsByAzmoon(long AzmoonId);

        

        Task Import_Question_Answer_User(List<List<bool>> Answers, long Id_Azmoon, string Username);
    }
}
