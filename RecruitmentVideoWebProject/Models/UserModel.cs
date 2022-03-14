using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitmentVideoWebProject.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string UserMail { get; set; }
    }
}