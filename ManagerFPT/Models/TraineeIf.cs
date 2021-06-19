using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagerFPT.Models
{
    public class TraineeIf : UserInfor
    {
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}