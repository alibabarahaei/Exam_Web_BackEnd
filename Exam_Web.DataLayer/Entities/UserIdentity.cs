using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Exam_Web.DataLayer.Entities
{
    public class UserIdentity:IdentityUser
    {



        #region Relation

        public ICollection<User_Azmoon_Test_Answer> UserId { get; set; }

        #endregion

    }
}
