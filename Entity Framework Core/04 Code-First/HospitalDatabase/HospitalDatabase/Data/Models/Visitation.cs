using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static P01_HospitalDatabase.Data.DataValidations.Visitation;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        public int VisitationId { get; set; }

        public  DateTime Date { get; set; }

        [MaxLength(CommentsMaxLength)]
        public string Comments { get; set; }

        public  string Patient { get; set; }
    }
}
