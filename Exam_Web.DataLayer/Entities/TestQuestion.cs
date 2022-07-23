using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Web.DataLayer.Entities
{
    public class TestQuestion
    {





        public int TestQuestionId { get; set; }


        public string Title { get; set; }

        public string? SubTitle { get; set; }

        public string Question { get; set; }

        public string? Gozine1 { get; set; }
        public string? Gozine2 { get; set;}
        public string? Gozine3 { get; set; }
        public string? Gozine4 { get; set;}


        #region Relation

        public ICollection<Azmoon> Azmoons { get; set; }
        public ICollection<User_Azmoon_Test_Answer> TestId { get; set; }

        #endregion


    }
}
