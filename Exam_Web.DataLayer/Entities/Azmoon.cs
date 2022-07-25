namespace Exam_Web.DataLayer.Entities
{
    public class Azmoon
    {




        public long AzmoonId { get; set; }


        public string Title { get; set; }

        public string? SubTitle { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public long? UsedTime { get; set; }


        #region Relation

        public ICollection<TestQuestion> TestQuestions { get; set; }


        public ICollection<User_Azmoon_Test_Answer> Azmoonid { get; set; }

        #endregion

    }
}
