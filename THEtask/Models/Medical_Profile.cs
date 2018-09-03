using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEtask.Models
{
    public class Medical_Profile
    {

        public int Id { get; set; }
        [Display(Name = "Weight")]
        public decimal Weight { get; set; }
        [Display(Name = "Height")]
        public decimal Height { get; set; }
        [Display(Name = "Goal of diet")]
        public string Goal_of_diet { get; set; }
        [Display(Name = "Exercise Time")]
        public int Exercise_Time { get; set; }
        [Display(Name = "Level of Exercise")]
        public string Leve_of_Exercise { get; set; }
        [Display(Name = "Daily Food")]
        public string Daily_Food { get; set; }
        [Display(Name = "Vitamins")]
        public string Vitamins { get; set; }
        [Display(Name = "Problem History")]
        public string Problem_History { get; set; }
        
        public string User { get; set; }

    }
}